<template>
  <view class="fee-documentation">
    <!-- 是否缴纳勘费 -->
    <view class="input-group">
      <view class="title">
        <text class="title-text">是否缴纳勘费</text>
      </view>
      <view class="input-wrapper">
        <radio-group
          @change="onIfPaySurveyFeeTypeChange"
          class="j-flex j-flex-row j-w-100"
          style="justify-content: space-around; align-items: center"
        >
          <label
            class="j-flex j-flex-row j-flex-center"
            v-for="(item, index) in ifPaySurveyFeeTypes"
            :key="item.value"
          >
            <view>
              <radio
                :value="item.value"
                :checked="index === ifPaySurveyFeeTypesCurrent"
              />
            </view>
            <view>{{ item.value }}</view>
          </label>
        </radio-group>
      </view>
    </view>

    <!-- 勘探缴费时间 -->
    <view
      class="input-group j-flex j-flex-row "
      v-show="ifPaySurveyFeeTypesCurrent === 0"
    >
      <view class="title">
        <text class="title-text">勘探缴费时间</text>
      </view>
      <view class="input-inline-wrapper">
        <picker
          mode="date"
          :value="paySurveyFeeDate"
          @change="onPaySurveyFeeDateChange"
          class="text-center"
        >
          <view class="text-center">{{ paySurveyFeeDate }}</view>
        </picker>
      </view>
    </view>

    <!-- 考古发掘费缴纳时间 -->
    <view class="input-group j-flex j-flex-row ">
      <view class="title">
        <text class="title-text">考古发掘缴费时间</text>
      </view>
      <view class="input-inline-wrapper">
        <picker
          mode="date"
          :value="payExcavationFeeDate"
          @change="onPayExcavationFeeDateChange"
          class="text-center"
        >
          <view class="text-center">{{ payExcavationFeeDate }}</view>
        </picker>
      </view>
    </view>

    <!-- 工作信息表出具时间 -->
    <view class="input-group j-flex j-flex-row ">
      <view class="title">
        <text class="title-text">工作信息表出具时间</text>
      </view>
      <view class="input-inline-wrapper">
        <picker
          mode="date"
          :value="workInfoDocumentIssuanceDate"
          @change="onWorkInfoDocumentIssuanceDateChange"
          class="text-center"
        >
          <view class="text-center">{{ workInfoDocumentIssuanceDate }}</view>
        </picker>
      </view>
    </view>

    <!-- 完毕业务意见书出具情况 -->
    <view class="input-group " style="">
      <view><text style="">完毕业务意见书出具情况</text></view>
      <!-- 出具时间 -->
      <view class="input-group j-flex j-flex-row b-b-1-gray">
        <view class="title">
          <text class="title-text">出具时间</text>
        </view>
        <view class="input-inline-wrapper">
          <picker
            mode="date"
            :value="workFinishInfoDocumentIssuanceDate"
            @change="onWorkFinishInfoDocumentIssuanceDateChange"
            class="text-center"
          >
            <view class="text-center">{{
              workFinishInfoDocumentIssuanceDate
            }}</view>
          </picker>
        </view>
      </view>
      <!-- 通知项目单位领取时间 -->
      <view class="input-group j-flex j-flex-row b-b-1-gray">
        <view class="title">
          <text class="title-text">通知项目单位领取时间</text>
        </view>
        <view class="input-inline-wrapper">
          <picker
            mode="date"
            :value="noticeOfReceiveWorkFinishInfoDocumentDate"
            @change="onNoticeOfReceiveWorkFinishInfoDocumentDateChange"
            class="text-center"
          >
            <view class="text-center">{{
              noticeOfReceiveWorkFinishInfoDocumentDate
            }}</view>
          </picker>
        </view>
      </view>
      <!-- 是否领取 -->
      <view class="input-group j-flex j-flex-row b-b-1-gray">
        <view class="title j-flex j-flex-row j-flex-center ">
          <text class="title-text">是否领取</text>
        </view>
        <view class="input-inline-wrapper j-flex j-flex-row j-flex-center ">
          <switch
            @change="receivedWorkFinishInfoDocumentChange"
            :checked="receivedWorkFinishInfoDocument"
            style=""
          />
        </view>
      </view>
    </view>

    <!-- 完毕通知书出具情况 -->
    <view class="input-group " style="">
      <view><text style="">完毕通知书出具情况</text></view>
      <!-- 出具时间 -->
      <view class="input-group j-flex j-flex-row b-b-1-gray">
        <view class="title">
          <text class="title-text">出具时间</text>
        </view>
        <view class="input-inline-wrapper">
          <picker
            mode="date"
            :value="finishDocumentIssuanceDate"
            @change="onFinishDocumentIssuanceDateChange"
            class="text-center"
          >
            <view class="text-center">{{ finishDocumentIssuanceDate }}</view>
          </picker>
        </view>
      </view>
      <!-- 通知项目单位领取时间 -->
      <view class="input-group j-flex j-flex-row b-b-1-gray">
        <view class="title">
          <text class="title-text">通知项目单位领取时间</text>
        </view>
        <view class="input-inline-wrapper">
          <picker
            mode="date"
            :value="noticeOfReceiveFinishDocumentDate"
            @change="onNoticeOfReceiveFinishDocumentDateChange"
            class="text-center"
          >
            <view class="text-center">{{
              noticeOfReceiveFinishDocumentDate
            }}</view>
          </picker>
        </view>
      </view>
      <!-- 是否领取 -->
      <view class="input-group j-flex j-flex-row b-b-1-gray">
        <view class="title j-flex j-flex-row j-flex-center ">
          <text class="title-text">是否领取</text>
        </view>
        <view class="input-inline-wrapper j-flex j-flex-row j-flex-center ">
          <switch
            @change="receivedFinishDocumentChange"
            :checked="receivedFinishDocument"
            style=""
          />
        </view>
      </view>
    </view>

    <!-- 项目考古工作完成 -->
    <view class="input-group j-flex j-flex-row b-b-1-gray">
      <view class="title j-flex j-flex-row j-flex-center ">
        <text class="title-text">项目考古工作完成</text>
      </view>
      <view class="input-inline-wrapper j-flex j-flex-row j-flex-center ">
        <switch @change="allFinishChange" :checked="allFinish" style="" />
      </view>
    </view>
  </view>
</template>

<script>
export default {
  components: {},
  props: {},
  data() {
    return {
      ifPaySurveyFeeTypes: [
        {
          value: '是'
        },
        {
          value: '调查方式无需缴费'
        },
        {
          value: '否'
        }
      ],
      ifPaySurveyFeeTypesCurrent: 2,

      paySurveyFeeDate: '',

      payExcavationFeeDate: '',

      workInfoDocumentIssuanceDate: '',

      //完毕业务意见书出具情况
      workFinishInfoDocumentIssuanceDate: '',

      noticeOfReceiveWorkFinishInfoDocumentDate: '',

      receivedWorkFinishInfoDocument: false,

      //完毕通知书出具情况
      finishDocumentIssuanceDate: '',

      noticeOfReceiveFinishDocumentDate: '',

      receivedFinishDocument: false,

      allFinish: false
    }
  },
  computed: {},
  watch: {},
  created() {},
  mounted() {},
  methods: {
    onIfPaySurveyFeeTypeChange(e) {
      for (let i = 0; i < this.ifPaySurveyFeeTypes.length; i++) {
        if (this.ifPaySurveyFeeTypes[i].value === e.target.value) {
          this.ifPaySurveyFeeTypesCurrent = i
          break
        }
      }
    },

    onPaySurveyFeeDateChange(e) {
      this.paySurveyFeeDate = e.detail.value
    },

    onPayExcavationFeeDateChange(e) {
      this.payExcavationFeeDate = e.detail.value
    },

    onWorkInfoDocumentIssuanceDateChange(e) {
      this.workInfoDocumentIssuanceDate = e.detail.value
    },

    onWorkFinishInfoDocumentIssuanceDateChange(e) {
      this.workFinishInfoDocumentIssuanceDate = e.detail.value
    },

    onNoticeOfReceiveWorkFinishInfoDocumentDateChange(e) {
      this.noticeOfReceiveWorkFinishInfoDocumentDate = e.detail.value
    },

    receivedWorkFinishInfoDocumentChange(e) {
      this.receivedWorkFinishInfoDocument = e.detail.value
    },

    onFinishDocumentIssuanceDateChange(e) {
      this.finishDocumentIssuanceDate = e.detail.value
    },

    onNoticeOfReceiveFinishDocumentDateChange(e) {
      this.noticeOfReceiveFinishDocumentDate = e.detail.value
    },

    receivedFinishDocumentChange(e) {
      this.receivedFinishDocument = e.detail.value
    },

    allFinishChange(e) {
      this.allFinish = e.detail.value
    },

    getVM() {
      const obj = {
        ifPaySurveyFee: this.ifPaySurveyFeeTypes[
          this.ifPaySurveyFeeTypesCurrent
        ].value,
        paySurveyFeeDate: this.paySurveyFeeDate,
        payExcavationFeeDate: this.payExcavationFeeDate,
        workInfoDocumentIssuanceDate: this.workInfoDocumentIssuanceDate,
        workFinishInfoDocumentIssuanceDate: this
          .workFinishInfoDocumentIssuanceDate,
        noticeOfReceiveWorkFinishInfoDocumentDate: this
          .noticeOfReceiveWorkFinishInfoDocumentDate,
        receivedWorkFinishInfoDocument: this.receivedWorkFinishInfoDocument,
        finishDocumentIssuanceDate: this.finishDocumentIssuanceDate,
        noticeOfReceiveFinishDocumentDate: this
          .noticeOfReceiveFinishDocumentDate,
        receivedFinishDocument: this.receivedFinishDocument,
        allFinish: this.allFinish
      }

      return obj
    },

    setVM(obj) {
      const ifPaySurveyFee = obj.ifPaySurveyFee
      this.ifPaySurveyFeeTypes.every((item, index) => {
        if (item.value === ifPaySurveyFee) {
          this.ifPaySurveyFeeTypesCurrent = index
          return false
        }
        return true
      })

      this.paySurveyFeeDate = this.getYMD(obj.paySurveyFeeDate)
      this.payExcavationFeeDate = this.getYMD(obj.payExcavationFeeDate)
      this.workInfoDocumentIssuanceDate = this.getYMD(
        obj.workInfoDocumentIssuanceDate
      )
      this.workFinishInfoDocumentIssuanceDate = this.getYMD(
        obj.workFinishInfoDocumentIssuanceDate
      )
      this.noticeOfReceiveWorkFinishInfoDocumentDate = this.getYMD(
        obj.noticeOfReceiveWorkFinishInfoDocumentDate
      )
      this.receivedWorkFinishInfoDocument = obj.receivedWorkFinishInfoDocument
      this.finishDocumentIssuanceDate = this.getYMD(
        obj.finishDocumentIssuanceDate
      )
      this.noticeOfReceiveFinishDocumentDate = this.getYMD(
        obj.noticeOfReceiveFinishDocumentDate
      )
      this.receivedFinishDocument = obj.receivedFinishDocument
      this.allFinish = obj.allFinish
    }
  }
}
</script>

<style lang="scss" scoped>
.fee-documentation {
  .b-b-1-gray {
    border-bottom: 1px solid #ddd;
  }
}
</style>
