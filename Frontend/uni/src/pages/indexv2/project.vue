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
            <basic ref="basic" />

            <view style="padding-bottom: 25px">
              <button
                class="share-button j-theme-bg m-b-100"
                @click="onCommit()"
              >
                提交
              </button></view
            >
          </scroll-view>
        </swiper-item>

        <swiper-item @touchmove.stop>
          <scroll-view
            scroll-y="true"
            :style="{ height: layoutContentHeight + 'px' }"
          >
            <survey ref="survey" />
            <view style="padding-bottom: 25px">
              <button
                class="share-button j-theme-bg m-b-100"
                @click="onCommit()"
              >
                提交
              </button></view
            >
          </scroll-view>
        </swiper-item>

        <swiper-item @touchmove.stop>
          <scroll-view
            scroll-y="true"
            :style="{
              height: layoutContentHeight + 'px'
            }"
          >
            <excavate ref="excavate" />
            <view style="padding-bottom: 25px">
              <button
                class="share-button j-theme-bg m-b-100"
                @click="onCommit()"
              >
                提交
              </button></view
            >
          </scroll-view>
        </swiper-item>

        <swiper-item @touchmove.stop>
          <scroll-view
            scroll-y="true"
            :style="{
              height: layoutContentHeight + 'px'
            }"
          >
            <fee-documentation ref="feeDocumentation" />
            <view style="padding-bottom: 25px">
              <button
                class="share-button j-theme-bg m-b-100"
                @click="onCommit()"
              >
                提交
              </button></view
            >
          </scroll-view>
        </swiper-item>
      </swiper>
    </div>
  </view>
</template>

<script>
import uniSteps from '@/components/uni-steps/uni-steps.vue'
import basic from '@/components/proj/v2/basic.vue'
// import hasSurveyCondition from '@/components/proj/v2/has-survey-condition.vue'
import survey from '@/components/proj/v2/survey.vue'
import excavate from '@/components/proj/v2/excavate.vue'
import feeDocumentation from '@/components/proj/v2/fee-documentation.vue'

export default {
  name: '',
  data() {
    return {
      id: -1,
      stepIndex: 0,
      layoutContentHeight: 0,
      steps: [
        { title: '基本信息' },
        { title: '考古勘探' },
        { title: '考古发掘' },
        { title: '费用和手续' }
      ]
    }
  },
  components: {
    uniSteps,
    basic,
    // hasSurveyCondition
    survey,
    excavate,
    feeDocumentation
  },
  computed: {},
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

    swiperCanTouchMove() {
      return false
    },
    swiperChange(e) {
      this.stepIndex = e.detail.current
    },
    stepClicked(e) {
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
    },
    onCommit() {
      console.log('------------------------------------')
      const vm = this.getVM()
      if (!vm) {
        return
      }
      uni.showLoading({ title: '请稍后...' })
      uni
        .request({
          url: this.BaseUrl + '/api/services/app/FJ2/Commit',
          method: 'POST',
          data: vm,
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
            }
          })
        })
    },
    getVM() {
      const basic = this.$refs.basic
      const survey = this.$refs.survey
      const excavate = this.$refs.excavate
      const feeDocumentation = this.$refs.feeDocumentation

      const basicVM = basic.getVM()
      const surveyVM = survey.getVM()
      const excavateVM = excavate.getVM()
      const feeDocumentationVM = feeDocumentation.getVM()

      const vm = {}
      if (this.id || this.id >= 0) {
        vm.id = this.id
      }
      Object.assign(vm, basicVM, surveyVM, excavateVM, feeDocumentationVM)

      console.log(vm)
      return vm
    },

    requestData() {
      const self = this
      this.requestOptions()
        .then(options => {
          uni.hideLoading()
          console.log(44)
          self.setOptions(self, options)
          console.log(22)
          if (!self.id || self.id < 0) {
            return
          }
          self.requestVM(self.id)
        })
        .catch(() => {
          uni.hideLoading()
          uni.showToast({
            title: '获取数据失败，请重试11',
            duration: 1500
          })
        })
    },

    setOptions(self, options) {
      console.log(options)
      const basic = self.$refs.basic
      const survey = self.$refs.survey
      const excavate = self.$refs.excavate

      basic.landProps = options[0].values
      basic.notSurveyReasonItems = options[1].values
        .map(x => {
          return { value: x }
        })
        .concat(basic.notSurveyReasonItems)

      survey.notHaveTheConditionsForSurveyReasonItems = options[2].values
        .map(x => {
          return { value: x }
        })
        .concat(survey.notHaveTheConditionsForSurveyReasonItems)

      survey.remainTypes = options[3].values
      survey.remainPeriods = options[4].values

      survey.estimateExcavateAreas = options[5].values
        .map(x => {
          return { value: x }
        })
        .concat(survey.estimateExcavateAreas)

      survey.estimateExcavateDurations = options[6].values
        .map(x => {
          return { value: x }
        })
        .concat(survey.estimateExcavateDurations)

      excavate.notHaveTheConditionsForExcavationReasonItems = options[7].values
        .map(x => {
          return { value: x }
        })
        .concat(excavate.notHaveTheConditionsForExcavationReasonItems)
    },

    requestVM(id) {
      const self = this
      uni.showLoading({ title: '' })
      uni
        .request({
          url: this.BaseUrl + '/api/services/app/FJ2/Get',
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

          self.setVM(result)
        })
    },

    setVM(obj) {
      console.log(obj)
      const basic = this.$refs.basic
      const survey = this.$refs.survey
      const excavate = this.$refs.excavate
      const feeDocumentation = this.$refs.feeDocumentation

      this.id = obj.id
      basic.setVM(obj)
      survey.setVM(obj)
      excavate.setVM(obj)
      feeDocumentation.setVM(obj)
    },

    requestOptions() {
      const types = [
        'LandProps',
        'NotSurveyReasons',
        'NotHaveTheConditionsForSurveyReasons',
        'RemainTypes',
        'RemainPeriods',
        'EstimateExcavateAreas',
        'EstimateExcavateDurations',
        'NotHaveTheConditionsForExcavationReasons'
      ]

      const promises = []
      const self = this
      types.forEach(x => {
        promises.push(self.requestOption(x))
      })
      uni.showLoading({ title: '' })

      return Promise.all(promises)
    },
    requestOption(type) {
      return new Promise((resolve, reject) => {
        uni
          .request({
            url: this.BaseUrl + '/api/services/app/Option/GetByType',
            data: { type: type }
          })
          .then(pro => {
            var [error, res] = pro
            if (error || !res.data.success || res.statusCode !== 200) {
              reject()
            }
            const d = res.data.result
            resolve(d)
          })
      })
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
