<template>
  <!-- 提交资料和签协议 -->
  <view class="protocol">
    <uni-collapse>
      <uni-collapse-item
        title="委托资料和协议"
        :open="collapseOpen"
        :showAnimation="true"
        :disabled="collapseDisabled"
      >
        <!-- 委托资料提交时间 -->
        <view class="input-group j-flex j-flex-row ">
          <view class="title">
            <text class="title-text title-text-require">委托资料提交时间</text>
          </view>
          <view class="input-inline-wrapper">
            <picker
              mode="date"
              :value="documentSubmitDate"
              @change="documentSubmitDateChange"
              class="text-center"
              :disabled="!formEnable"
            >
              <view class="text-center">{{ documentSubmitDate }}</view>
            </picker>
          </view>
        </view>

        <!-- 资料审核完成时间 -->
        <view class="input-group j-flex j-flex-row ">
          <view class="title">
            <text class="title-text title-text-require">资料审核完成时间</text>
          </view>
          <view class="input-inline-wrapper">
            <picker
              mode="date"
              :value="documentReviewCompletedDate"
              @change="documentReviewCompletedDateChange"
              class="text-center"
              :disabled="!formEnable"
            >
              <view class="text-center">{{ documentReviewCompletedDate }}</view>
            </picker>
          </view>
        </view>

        <!-- 是否签订协议 -->
        <view class="input-group j-flex j-flex-row ">
          <view class="title">
            <text class="title-text title-text-require">是否签订协议</text>
          </view>
          <view class="input-inline-wrapper m-l-30">
            <switch
              :checked="protocoled"
              type="checkbox"
              @change="protocolChange"
              :disabled="!formEnable"
            />
          </view>
        </view>

        <!-- 协议签订时间 -->
        <view v-show="protocoled" class="input-group j-flex j-flex-row ">
          <view class="title">
            <text class="title-text title-text-require">协议签订时间</text>
          </view>
          <view class="input-inline-wrapper">
            <picker
              mode="date"
              :value="protocoledDate"
              @change="protocoledDateChange"
              class="text-center"
              :disabled="!formEnable"
            >
              <view class="text-center">{{ protocoledDate }}</view>
            </picker>
          </view>
        </view>
        <!-- 未签订协议原因 -->
        <view v-show="!protocoled" class="input-group j-flex j-flex-row ">
          <view class="title">
            <text class="title-text title-text-require">未签订原因</text>
          </view>
          <view class="input-inline-wrapper">
            <picker
              mode="selector"
              :value="unProtocolReasonIndex"
              :range="unProtocolReasons"
              range-key="name"
              class="text-center"
              @change="unProtocolReasonChange"
              :disabled="!formEnable"
            >
              <view class="text-center">{{
                unProtocolReasons[unProtocolReasonIndex].name
              }}</view>
            </picker>
          </view>
        </view>
      </uni-collapse-item>
    </uni-collapse>
  </view>
</template>

<script>
import uniCollapse from '@/components/uni-collapse/uni-collapse.vue'
import uniCollapseItem from '@/components/uni-collapse-item/uni-collapse-item.vue'
export default {
  components: { uniCollapse, uniCollapseItem },
  props: {
    collapseOpen: {
      type: Boolean,
      default: false
    },
    collapseDisabled: {
      type: Boolean,
      default: false
    },
    formEnable: {
      type: Boolean,
      default: true
    }
  },
  data() {
    return {
      documentSubmitDate: '',
      documentReviewCompletedDate: '',

      protocoled: true,
      protocoledDate: '',
      unProtocolReasonIndex: 0,
      unProtocolReasons: [
        { name: '资料审核不通过' },
        { name: '资料不完成' },
        { name: '现场不适合勘探' }
      ]
    }
  },
  computed: {},
  watch: {},
  created() {},
  mounted() {},
  methods: {
    documentSubmitDateChange(e) {
      this.documentSubmitDate = e.target.value
    },
    documentReviewCompletedDateChange(e) {
      this.documentReviewCompletedDate = e.target.value
    },
    protocolChange(e) {
      this.protocoled = e.target.value
    },
    protocoledDateChange(e) {
      this.protocoledDate = e.target.value
    },
    unProtocolReasonChange(e) {
      this.unProtocolReasonIndex = e.detail.value
    }
  }
}
</script>

<style lang="scss" scoped></style>
