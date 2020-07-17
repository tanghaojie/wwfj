<template>
  <view class="main j-flex j-flex-column">
    <div class="layout-top m-b-30">
      <view class="top-space"></view>

      <view class="steps"
        ><uni-steps
          :options="steps"
          :active="stepIndex"
          @itemTextClicked="stepClicked"
          @itemLineClicked="stepClicked"
          active-color="#007aff"
        ></uni-steps
      ></view>
    </div>

    <div class="layout-content">
      <swiper
        class="swiper"
        @change="swiperChange"
        :current="stepIndex"
        :style="{ height: layoutContentHeight + 'px' }"
        disable-touch="true"
      >
        <swiper-item @touchmove.stop>
          <scroll-view
            scroll-y="true"
            :style="{
              height: layoutContentHeight + 'px'
            }"
          >
            <basic
              ref="basic"
              :collapse-open="true"
              :form-enable="isTanKanYeWuBuMen"
              :collapse-disabled="false"
              :loc-region-enable="!isTanKanYeWuBuMen"
            />
            <protocol
              ref="protocol"
              :style="protocolVisible ? '' : 'display:none'"
              :collapse-open="isWaitProtocol"
              :collapse-disabled="isWaitProtocol"
              :form-enable="isTanKanBan"
            />

            <button
              class="share-button j-theme-bg m-b-100"
              @click="onCommit(0)"
            >
              提交
            </button>
          </scroll-view>
        </swiper-item>
        <swiper-item @touchmove.stop>
          <scroll-view
            scroll-y="true"
            :style="{ height: layoutContentHeight + 'px' }"
          >
            <explore-pay
              ref="explorPay"
              :style="explorePayVisible ? '' : 'display:none'"
              :form-enable="isProtocoled && isTanKanBan"
              :collapse-open="isProtocoled"
              :collapse-disabled="false"
            />

            <explore
              ref="explore"
              :style="exploreVisible ? '' : 'display:none'"
              :collapse-open="isExploring"
              :collapse-disabled="false"
              :form-enable="isTanKanYeWuBuMen"
            />

            <button
              class="share-button j-theme-bg m-b-100"
              @click="onCommit(1)"
            >
              提交
            </button>
          </scroll-view>
        </swiper-item>
        <swiper-item @touchmove.stop>
          <scroll-view
            scroll-y="true"
            :style="{
              height: layoutContentHeight + 'px'
            }"
          >
            <dig
              ref="dig"
              :style="digAndReportVisible ? '' : 'display:none'"
              :collapse-open="true"
              :form-enable="isFaJueXianChangeFuZeRen"
            />

            <button
              class="share-button j-theme-bg m-b-100"
              @click="onCommit(2)"
            >
              提交
            </button>
          </scroll-view>
        </swiper-item>
        <swiper-item @touchmove.stop>
          <scroll-view
            scroll-y="true"
            :style="{
              height: layoutContentHeight + 'px'
            }"
          >
            <reportInfo
              ref="reportInfo"
              :style="digAndReportVisible ? '' : 'display:none'"
              :collapse-open="true"
              :formEnableIndex="
                isTanKanYeWuBuMen ? 0 : isTanKanBan ? 1 : isWenBaoChu ? 2 : -1
              "
            />

            <button
              class="share-button j-theme-bg m-b-100"
              @click="onCommit(3)"
            >
              提交
            </button>
          </scroll-view>
        </swiper-item>
      </swiper>
    </div>
  </view>
</template>

<script>
import uniSteps from '@/components/uni-steps/uni-steps.vue'
import basic from '@/components/proj/basic.vue'
import explorePay from '@/components/proj/explore-pay.vue'
import explore from '@/components/proj/explore.vue'
import protocol from '@/components/proj/protocol.vue'
import dig from '@/components/proj/dig.vue'
import reportInfo from '@/components/proj/report-info.vue'

export default {
  name: '',
  data() {
    return {
      id: -1,
      state: 0,
      stepIndex: 0,
      layoutContentHeight: 0,
      steps: [
        { title: '资料提交' },
        { title: '考古勘探' },
        { title: '考古发掘' },
        { title: '结束' }
      ],
      steps_all: [
        { title: '资料提交' },
        { title: '考古勘探' },
        { title: '考古发掘' },
        { title: '结束' }
      ],
      steps_unprotocol: [{ title: '资料提交', desc: '未签订协议' }],
      steps_undig: [
        { title: '资料提交' },
        { title: '考古勘探', desc: '不考古发掘' }
      ]
    }
  },
  components: {
    uniSteps,
    basic,
    explorePay,
    explore,
    protocol,
    dig,
    reportInfo
  },
  computed: {
    //新建项目
    isNewProj() {
      return this.state === null
    },
    //已新建项目，等着签协议
    isWaitProtocol() {
      return this.state === this.State.New
    },
    //未签订协议  finished
    isUnProtocoled() {
      return this.state === this.State.UnProtocoled
    },
    //已经提交资料签订了协议，未缴费
    isProtocoled() {
      return this.state === this.State.Protocoled
    },
    //已缴费，勘探中
    isExploring() {
      return this.state === this.State.Exploring
    },
    // 勘探完成，不转考古 finish
    isUnDig() {
      return this.state === this.State.UnDig
    },
    // 勘探完成，转考古，考古发掘中
    isDiging() {
      return this.state === this.State.Diging
    },
    // 考古发掘完成 finish
    isDiged() {
      return this.state === this.State.Diged
    },

    protocolVisible() {
      return (
        this.isWaitProtocol ||
        this.isUnProtocoled ||
        this.isProtocoled ||
        this.isExploring ||
        this.isUnDig ||
        this.isDiging ||
        this.isDiged
      )
    },
    explorePayVisible() {
      let visible =
        this.isProtocoled ||
        this.isExploring ||
        this.isUnDig ||
        this.isDiging ||
        this.isDiged
      return visible
    },
    exploreVisible() {
      return this.isExploring || this.isUnDig || this.isDiging || this.isDiged
    },
    digAndReportVisible() {
      return this.isDiging || this.isDiged
    },
    isTanKanYeWuBuMen() {
      const x =
        this.$store.state.hasLogin &&
        this.$store.state.department === this.Department.KanTanYeWu
      return x
    },
    isTanKanBan() {
      return (
        this.$store.state.hasLogin &&
        this.$store.state.department === this.Department.KanTanBan
      )
    },
    isFaJueXianChangeFuZeRen() {
      return (
        this.$store.state.hasLogin &&
        this.$store.state.department === this.Department.FaJueXianChangeFuZeRen
      )
    },
    isWenBaoChu() {
      return (
        this.$store.state.hasLogin &&
        this.$store.state.department === this.Department.WenBaoChu
      )
    },
    isOther() {
      return (
        this.$store.state.hasLogin &&
        this.$store.state.department === this.Department.Other
      )
    }
  },
  watch: {},
  methods: {
    getDate(strDate) {
      const date = strDate ? new Date(strDate) : new Date()
      let year = date.getFullYear()
      let month = date.getMonth() + 1
      let day = date.getDate()
      month = month > 9 ? month : '0' + month
      day = day > 9 ? day : '0' + day
      return `${year}-${month}-${day}`
    },

    getCommitObj_Basic() {
      const basicImp = this.$refs.basic
      const {
        projName,
        locRegion,
        locDetail,
        projPropIndex,
        landPropIndex
      } = basicImp
      let regionName = locRegion.label
      let regionIndex = locRegion.index
      let regionCode = locRegion.code
      let projPropName = basicImp.projProps[projPropIndex].name
      let landPropName = basicImp.landProps[landPropIndex].name

      if (
        !projName ||
        !regionName ||
        !regionIndex ||
        !regionCode ||
        !locDetail ||
        !projPropName ||
        !landPropName
      ) {
        uni.showToast({
          title: '请填写完整信息',
          duration: 1500
        })
        return
      }

      let obj = {
        state: this.State.New,

        name: projName,
        regionCode: regionCode,
        regionName: regionName,
        regionIndex: regionIndex.toString(),
        locationDetail: locDetail,
        projPropertyName: projPropName,
        projPropertyIndex: projPropIndex,
        landPropertyName: landPropName,
        landPropertyIndex: landPropIndex
      }
      return obj
    },
    getCommitObj_Protocol(obj) {
      if (!obj) {
        return
      }
      obj.id = this.id

      const protocolImp = this.$refs.protocol
      const {
        documentSubmitDate,
        documentReviewCompletedDate,
        protocoled,
        protocoledDate,
        unProtocolReasonIndex
      } = protocolImp

      var qq = protocoled && !protocoledDate
      var ww =
        !protocoled &&
        (unProtocolReasonIndex === null ||
          unProtocolReasonIndex === undefined ||
          unProtocolReasonIndex < 0)
      var xx = qq || ww
      if (!documentSubmitDate || !documentReviewCompletedDate || xx) {
        uni.showToast({
          title: '请填写完整信息',
          duration: 1500
        })
        return
      }

      obj.state = protocoled ? this.State.Protocoled : this.State.UnProtocoled

      obj.documentSubmitDate = documentSubmitDate
      obj.documentReviewCompletedDate = documentReviewCompletedDate
      obj.protocoledDate = protocoled ? protocoledDate : undefined
      obj.unProtocoledReason = protocoled
        ? undefined
        : protocolImp.unProtocolReasons[unProtocolReasonIndex].name
      obj.unProtocoledReasonIndex = protocoled
        ? undefined
        : unProtocolReasonIndex

      return obj
    },
    getCommitObj_ExplorePay(obj) {
      if (!obj) {
        return
      }

      obj.id = this.id

      const explorPayImp = this.$refs.explorPay
      const { explorePaidDate } = explorPayImp

      if (!explorePaidDate || explorePaidDate === '') {
        uni.showToast({
          title: '请缴费',
          duration: 1500
        })
        return
      }

      obj.state = this.State.Exploring
      obj.explorePaidDate = explorePaidDate
      return obj
    },
    getCommitObj_Explore(obj) {
      if (!obj) {
        return
      }

      obj.id = this.id

      const exploreImp = this.$refs.explore
      const {
        exploreStartDate,
        exploreEndDate,
        ifDig,
        situation,
        estimateArea,
        estimateFinishDate
      } = exploreImp

      obj.exploreStartDate = exploreStartDate
      obj.exploreEndDate = exploreEndDate
      obj.situation = ifDig ? situation : undefined
      obj.estimateArea = ifDig ? estimateArea : undefined
      obj.estimateFinishDate = ifDig ? estimateFinishDate : undefined

      obj.state = ifDig ? this.State.Diging : this.State.UnDig
      return obj
    },
    getCommitObj_Diging(obj) {
      if (!obj) {
        return
      }

      obj.id = this.id

      const digImp = this.$refs.dig
      const reportInfoImp = this.$refs.reportInfo
      const {
        letterDateBeforeDig,
        impactSituationItems,
        protocoledDate,
        digPaidDate,
        startDigDate,
        endDigDate,
        stageReport
      } = digImp
      const {
        workInfoPublishDate,
        businessAdvicePublishDate,
        finishNoticePublishDate,
        allFinished
      } = reportInfoImp

      obj.letterDateBeforeDig = letterDateBeforeDig
      obj.impactSituationItems = impactSituationItems
        .filter(x => x.checked)
        .map(x => x.value)
      obj.digProtocoledDate = protocoledDate
      obj.digPaidDate = digPaidDate
      obj.digStartDate = startDigDate
      obj.digEndDate = endDigDate
      obj.stageReport = stageReport
      obj.workInfoPublishDate = workInfoPublishDate
      obj.businessAdvicePublishDate = businessAdvicePublishDate
      obj.finishNoticePublishDate = finishNoticePublishDate
      if (allFinished) {
        obj.state = this.State.Diged
      }

      return obj
    },

    getCommitObj(commitStep) {
      let obj = this.getCommitObj_Basic()
      if (this.isNewProj) {
        return obj
      }

      // 等待签协议， 或者 未签协议的改成 签协议
      obj = this.getCommitObj_Protocol(obj)
      if (this.isWaitProtocol || this.isUnProtocoled) {
        return obj
      }

      // 签了协议  缴费
      obj = this.getCommitObj_ExplorePay(obj)
      if (this.isProtocoled) {
        return obj
      }

      // 勘探中 或 勘探完成 不发掘  或 发掘
      obj = this.getCommitObj_Explore(obj)
      if (this.isExploring || this.isUnDig) {
        return obj
      }

      // 发掘中
      obj = this.getCommitObj_Diging(obj)
      if (this.isDiging) {
        return obj
      }

      return obj
    },

    onCommit(commitStep) {
      var requestObj = this.getCommitObj(commitStep)
      if (!requestObj) {
        return
      }
      uni.showLoading({ title: '请稍后...' })

      uni
        .request({
          url: this.BaseUrl + '/api/services/app/FJ/Commit',
          method: 'POST',
          data: requestObj,
          header: {
            'content-type': 'application/json'
          }
        })
        .then(data => {
          var [error, res] = data
          uni.hideLoading()
          if (error) {
            uni.showToast({
              title: '提交失败，请重试',
              duration: 1500
            })
            return
          }
          const pages = getCurrentPages()
          const beforePage = pages[pages.length - 2]
          uni.navigateBack({
            success: function() {
              beforePage.$vm.startPullDownRefresh()
              // uni.startPullDownRefresh()
            }
          })
        })
    },

    bandingBackendData(result) {
      this.id = result.id
      this.state = result.state
      this.steps = this.steps_all
      switch (this.state) {
        case this.State.New:
          this.stepIndex = 0
          break
        case this.State.UnProtocoled:
          this.stepIndex = 0
          this.steps = this.steps_unprotocol
          break
        case this.State.Protocoled:
          this.stepIndex = 1
          break
        case this.State.Exploring:
          this.stepIndex = 1
          break
        case this.State.UnDig:
          this.stepIndex = 1
          this.steps = this.steps_undig
          break
        case this.State.Diging:
          this.stepIndex = 2
          break
        case this.State.Diged:
          this.stepIndex = 3
          break

        default:
          break
      }

      // new
      const basicImp = this.$refs.basic
      basicImp.projName = result.name
      basicImp.locRegion.label = result.regionName
      basicImp.locRegion.index = result.regionIndex
        .split(',')
        .map(q => parseInt(q))
      basicImp.locRegion.code = result.regionCode
      basicImp.locDetail = result.locationDetail
      basicImp.projPropIndex = result.projPropertyIndex
      basicImp.landPropIndex = result.landPropertyIndex

      // protocol
      const protocolImp = this.$refs.protocol

      protocolImp.protocoled = !(result.state === this.State.UnProtocoled)
      protocolImp.documentSubmitDate = result.documentSubmitDate
        ? this.getDate(result.documentSubmitDate)
        : ''
      protocolImp.documentReviewCompletedDate = result.documentReviewCompletedDate
        ? this.getDate(result.documentReviewCompletedDate)
        : ''
      protocolImp.protocoledDate = result.protocoledDate
        ? this.getDate(result.protocoledDate)
        : ''
      if (result.unProtocoledReasonIndex) {
        protocolImp.unProtocolReasonIndex = result.unProtocoledReasonIndex
      }

      // explore pay
      const explorPayImp = this.$refs.explorPay
      explorPayImp.explorePaidDate = result.explorePaidDate
        ? this.getDate(result.explorePaidDate)
        : ''

      // explore
      const exploreImp = this.$refs.explore
      exploreImp.exploreStartDate = result.exploreStartDate
        ? this.getDate(result.exploreStartDate)
        : ''
      exploreImp.exploreEndDate = result.exploreEndDate
        ? this.getDate(result.exploreEndDate)
        : ''
      exploreImp.ifDig = !(result.state === this.State.UnDig)
      exploreImp.situation = result.situation
      exploreImp.estimateArea = result.estimateArea
      exploreImp.estimateFinishDate = result.estimateFinishDate
        ? this.getDate(result.estimateFinishDate)
        : ''

      // dig
      const digImp = this.$refs.dig
      digImp.letterDateBeforeDig = result.letterDateBeforeDig
        ? this.getDate(result.letterDateBeforeDig)
        : ''
      digImp.impactSituationItems.forEach(x => {
        if (result.impactSituationItems.includes(x.value)) {
          x.checked = true
        }
      })
      digImp.protocoledDate = result.digProtocoledDate
        ? this.getDate(result.digProtocoledDate)
        : ''
      digImp.digPaidDate = result.digPaidDate
        ? this.getDate(result.digPaidDate)
        : ''
      digImp.startDigDate = result.digStartDate
        ? this.getDate(result.digStartDate)
        : ''
      digImp.endDigDate = result.digEndDate
        ? this.getDate(result.digEndDate)
        : ''
      digImp.stageReport = result.stageReport

      const reportInfoImp = this.$refs.reportInfo
      reportInfoImp.workInfoPublishDate = result.workInfoPublishDate
        ? this.getDate(result.workInfoPublishDate)
        : ''
      reportInfoImp.businessAdvicePublishDate = result.businessAdvicePublishDate
        ? this.getDate(result.businessAdvicePublishDate)
        : ''
      reportInfoImp.finishNoticePublishDate = result.finishNoticePublishDate
        ? this.getDate(result.finishNoticePublishDate)
        : ''
      reportInfoImp.allFinished = result.state === this.State.Diged
    },

    requestData() {
      if (!this.id) {
        if (this.$store.state.hasLogin) {
          const basicImp = this.$refs.basic
          basicImp.locRegion.label = this.$store.state.regionName
          basicImp.locRegion.index = this.$store.state.regionIndex
            .split(',')
            .map(q => parseInt(q))
          basicImp.locRegion.code = this.$store.state.regionCode
        }
        this.state = null
        return
      }
      const self = this
      uni.showLoading({ title: '' })
      uni
        .request({
          url: this.BaseUrl + '/api/services/app/FJ/Get',
          data: { id: this.id }
        })
        .then(pro => {
          var [error, res] = pro
          uni.hideLoading()
          if (error || !res.data.success || res.statusCode !== 200) {
            let text = '获取数据失败，请重试'
            if (res && res.data && res.data.error && res.data.error.message) {
              text = res.data.error.message
            }
            uni.showToast({
              title: text,
              duration: 1500
            })
            return
          }
          let result = res.data.result
          if (!result || JSON.stringify(result) === '{}') {
            return
          }

          self.bandingBackendData(result)
        })
    },
    swiperCanTouchMove() {
      return false
    },
    swiperChange(e) {
      this.stepIndex = e.detail.current
    },
    stepClicked(e) {
      if (
        this.state <= this.State.New ||
        this.state <= this.State.UnProtocoled
      ) {
        if (e > 0) {
          return
        }
      }
      if (
        this.state <= this.State.Protocoled ||
        this.state <= this.State.Exploring ||
        this.state <= this.State.UnDig
      ) {
        if (e > 1) {
          return
        }
      }
      this.stepIndex = e
    },
    setupUI() {
      const query = uni.createSelectorQuery().in(this)
      const ltop = query.select('.layout-top')
      const sysInfo = uni.getSystemInfoSync()
      const sysWinHeight = sysInfo.windowHeight
      const self = this
      ltop
        .boundingClientRect(data => {
          self.layoutContentHeight = sysWinHeight - data.height
        })
        .exec()
    }
  },
  mounted() {
    this.$nextTick(() => {
      this.requestData()
    })
    this.setupUI()
  },
  onLoad(option) {
    this.id = option.id
    this.state = option.state
  }
}
</script>

<style lang="scss">
.main {
  background-color: #f1f1f1;
  font-size: 34rpx;

  .layout-top {
    flex: 0 0 auto;
    .top-space {
      height: 1rpx;
    }

    .steps {
      box-sizing: border-box;
      padding: 20rpx 0;
      background-color: white;
    }

    /deep/ .uni-steps__row-title {
      font-weight: 550;
    }
  }
  .layout-content {
    flex: 1 1 auto;
    /deep/ .input-group {
      // margin: 30rpx 0;
      margin: 15rpx 0;
      background-color: #ffffff;
      padding: 10rpx 16rpx;

      .title {
        .title-text {
          font-size: 34rpx;
          color: #222;
        }
      }
      .input-inline-wrapper {
        flex-grow: 1;
        display: flex;
        flex-direction: row;
        flex-wrap: nowrap;

        .text-center {
          height: 48rpx;
          font-size: 34rpx;
          flex: 1;
          width: 100%;
          text-align: center;
        }
      }
      .input-wrapper {
        margin-top: 15rpx;
        display: flex;
        flex-direction: row;
        flex-wrap: nowrap;

        .input {
          height: 48rpx;
          font-size: 32rpx;
          flex: 1;
        }
      }
    }
  }

  /deep/ .uni-collapse-cell__title-text {
    font-size: 34rpx;
  }

  .m-t-30 {
    margin-top: 30rpx;
  }
  .m-b-30 {
    margin-bottom: 30rpx;
  }
  .m-l-30 {
    margin-left: 30rpx;
  }
  .m-b-100 {
    margin-bottom: 100rpx;
  }

  .q {
    height: 4000rpx;
  }

  .share-button {
    margin-top: 30rpx;
    color: #fff;
  }
}
</style>
