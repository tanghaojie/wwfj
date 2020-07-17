<template>
  <view class="main">
    <view class="top-space"></view>

    <view class="content">
      <!-- 新增项目 -->
      <basic
        ref="basic"
        :form-enable="isNewProj"
        :collapse-disabled="isNewProj"
      />

      <!-- 提交资料和签协议 -->
      <protocol
        ref="protocol"
        :style="protocolVisible ? '' : 'display:none'"
        :collapse-open="isWaitProtocol"
        :collapse-disabled="isWaitProtocol"
      />

      <explore-pay
        ref="explorPay"
        :style="explorePayVisible ? '' : 'display:none'"
        :form-enable="isProtocoled"
        :collapse-open="isProtocoled"
        :collapse-disabled="isProtocoled"
      />

      <explore
        ref="explore"
        :style="exploreVisible ? '' : 'display:none'"
        :collapse-open="isExploring"
        :collapse-disabled="isExploring"
      />

      <dig
        ref="dig"
        :style="digAndReportVisible ? '' : 'display:none'"
        :collapse-open="isDiging"
      />

      <reportInfo
        ref="reportInfo"
        :style="digAndReportVisible ? '' : 'display:none'"
        :collapse-open="isDiging"
      />
    </view>

    <button class="share-button j-theme-bg m-b-100" @click="onCommit">
      提交
    </button>
  </view>
</template>

<script>
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
      state: 0
    }
  },
  components: {
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
      var ww = !protocoled && !unProtocolReasonIndex
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
        finishNoticePublishDate
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

      //  obj.state = this.State.UnDig
      return obj
    },

    getCommitObj() {
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

    onCommit() {
      var requestObj = this.getCommitObj()
      if (!requestObj) {
        return
      }
      uni.showLoading({
        title: '请稍后...'
      })

      uni
        .request({
          url: this.BaseUrl + '/api/services/app/FJ/Commit',
          method: 'POST',
          data: requestObj,
          header: {
            'content-type': 'application/json' //自定义请求头信息
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
    },

    requestData() {
      if (!this.id) {
        this.state = null
        return
      }
      const self = this
      uni.showLoading({
        title: ''
      })
      uni
        .request({
          url: this.BaseUrl + '/api/services/app/FJ/Get',
          data: {
            id: this.id
          }
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
    }
  },
  mounted() {
    this.$nextTick(() => {
      this.requestData()
    })
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
  height: 100vh;
  font-size: 34rpx;

  /deep/ .uni-collapse-cell__title-text {
    font-size: 34rpx;
  }

  .m-t-30 {
    margin-top: 30rpx;
  }
  .m-l-30 {
    margin-left: 30rpx;
  }
  .m-b-100 {
    margin-bottom: 100rpx;
  }

  .top-space {
    height: 1rpx;
  }

  .content {
    margin-top: 30rpx;
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

  .share-button {
    margin-top: 30rpx;
    color: #fff;
  }
}
</style>
