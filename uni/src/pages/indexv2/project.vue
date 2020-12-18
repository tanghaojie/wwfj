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

            <button class="share-button j-theme-bg m-b-100" @click="onCommit()">
              提交
            </button>
          </scroll-view>
        </swiper-item>

        <swiper-item @touchmove.stop>
          <scroll-view
            scroll-y="true"
            :style="{ height: layoutContentHeight + 'px' }"
          >
            <survey ref="survey" />
            <button class="share-button j-theme-bg m-b-100" @click="onCommit()">
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
            <excavate ref="excavate" />
            <button class="share-button j-theme-bg m-b-100" @click="onCommit()">
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
            <fee-documentation ref="feeDocumentation" />
            <button class="share-button j-theme-bg m-b-100" @click="onCommit()">
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
      stepIndex: 3,
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
      this.getVM()
    },
    getVM() {
      const basic = this.$refs.basic
      const survey = this.$refs.survey
      const excavate = this.$refs.excavate
      const feeDocumentation = this.$refs.feeDocumentation

      const basicObj = this.getBasicVM(basic)
      console.log(basicObj)
    },
    getBasicVM(basicRef) {
      const obj = {
        projName: basicRef.projName,
        projCompany: basicRef.projCompany,
        regionCode: basicRef.locRegion.code,
        regionName: basicRef.locRegion.label,
        regionIndex: basicRef.locRegion.index,
        locationDetail: basicRef.locDetail,
        landPropertyName: basicRef.landProps[basicRef.landPropIndex].name,
        landPropertyIndex: basicRef.landPropIndex,
        majorProj: basicRef.majorProj,
        documentSubmitDate: basicRef.documentSubmitDate,
        paperDocumentReviewCompletionDate:
          basicRef.paperDocumentReviewCompletionDate,
        onSiteVerificationCompletionDate:
          basicRef.onSiteVerificationCompletionDate,
        ifSurvey: basicRef.ifSurvey,
        surveyWorkType:
          basicRef.surveyWorkTypes[basicRef.surveyWorkTypesCurrent].value,
        ifSignSurveyAgreement: basicRef.ifSignSurveyAgreement,
        sendSurveyAgreementDate: basicRef.sendSurveyAgreementDate,
        replyStampedSurveyAgreementDate:
          basicRef.replyStampedSurveyAgreementDate,
        signSurveyAgreementDate: basicRef.signSurveyAgreementDate,
        surveyAgreementNumber: basicRef.surveyAgreementNumber,
        taskExclusionDate: basicRef.taskExclusionDate,
        surveyDepartment: basicRef.surveyDepartment
      }
      const notSurveyReasonItems = []
      basicRef.notSurveyReasonItems.forEach(q => {
        if (q.checked) {
          notSurveyReasonItems.push(q.value)
        }
      })
      if (notSurveyReasonItems.includes('其他')) {
        notSurveyReasonItems.splice(notSurveyReasonItems.indexOf('其他'), 1)
        notSurveyReasonItems.push(basicRef.otherNotSurveyReason)
      }
      obj.notSurveyReasons = notSurveyReasonItems
      return obj
    }
  },
  mounted() {
    this.$nextTick(() => {
      //   this.requestData()
    })
    this.setupUI()
  },
  onLoad(option) {
    // this.id = option.id
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
