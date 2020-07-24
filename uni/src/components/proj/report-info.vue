<template>
  <view class="explore-pay">
    <uni-collapse>
      <uni-collapse-item
        title="报表时间"
        :open="collapseOpen"
        :showAnimation="true"
        :disabled="collapseDisabled"
      >
        <!-- 现场移交出具手续时间 -->
        <view class="input-group j-flex j-flex-row ">
          <view class="title">
            <text class="title-text title-text-require"
              >现场移交出具手续时间</text
            >
          </view>
          <view class="input-inline-wrapper">
            <picker
              mode="date"
              :value="handoverData"
              @change="handoverDataChange"
              class="text-center"
              :disabled="formEnableIndex !== 0"
            >
              <view class="text-center">{{ handoverData }}</view>
            </picker>
          </view>
        </view>

        <!-- 出具《工作信息表》时间 -->
        <view class="input-group j-flex j-flex-row ">
          <view class="title">
            <text class="title-text title-text-require"
              >出具《工作信息表》时间</text
            >
          </view>
          <view class="input-inline-wrapper">
            <picker
              mode="date"
              :value="workInfoPublishDate"
              @change="workInfoPublishDateChange"
              class="text-center"
              :disabled="formEnableIndex !== 0"
            >
              <view class="text-center">{{ workInfoPublishDate }}</view>
            </picker>
          </view>
        </view>

        <!-- 出具《业务已经书》时间 -->
        <view class="input-group j-flex j-flex-row ">
          <view class="title">
            <text class="title-text title-text-require"
              >出具《业务已经书》时间</text
            >
          </view>
          <view class="input-inline-wrapper">
            <picker
              mode="date"
              :value="businessAdvicePublishDate"
              @change="businessAdvicePublishDateChange"
              class="text-center"
              :disabled="formEnableIndex !== 1"
            >
              <view class="text-center">{{ businessAdvicePublishDate }}</view>
            </picker>
          </view>
        </view>

        <!-- 出具《完毕通知书》时间 -->
        <view class="input-group j-flex j-flex-row ">
          <view class="title">
            <text class="title-text title-text-require"
              >出具《完毕通知书》时间</text
            >
          </view>
          <view class="input-inline-wrapper">
            <picker
              mode="date"
              :value="finishNoticePublishDate"
              @change="finishNoticePublishDateChange"
              class="text-center"
              :disabled="formEnableIndex !== 2"
            >
              <view class="text-center">{{ finishNoticePublishDate }}</view>
            </picker>
          </view>
        </view>

        <!-- 设置为完工 -->
        <view class="input-group j-flex j-flex-row ">
          <view class="title">
            <text class="title-text title-text-require">考古勘探发掘完成</text>
          </view>
          <view class="input-inline-wrapper">
            <switch @change="setAllFinished" :checked="allFinished" />
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
  props: {},
  data() {
    return {
      handoverData: '',
      workInfoPublishDate: '',
      businessAdvicePublishDate: '',
      finishNoticePublishDate: '',
      allFinished: false
    }
  },
  props: {
    collapseOpen: {
      type: Boolean,
      default: false
    },
    collapseDisabled: {
      type: Boolean,
      default: false
    },
    formEnableIndex: {
      type: Number,
      default: -1
    }
  },
  computed: {},
  watch: {},
  created() {},
  mounted() {},
  methods: {
    handoverDataChange(e) {
      this.handoverData = e.target.value
    },
    workInfoPublishDateChange(e) {
      this.workInfoPublishDate = e.target.value
    },
    businessAdvicePublishDateChange(e) {
      this.businessAdvicePublishDate = e.target.value
    },
    finishNoticePublishDateChange(e) {
      this.finishNoticePublishDate = e.target.value
    },
    setAllFinished(e) {
      this.allFinished = e.target.value
    }
  }
}
</script>

<style lang="scss" scoped>
.impactSituationItems {
  width: 100%;
  box-sizing: border-box;

  .impactSituationItem {
    padding: 15rpx 30rpx;
    width: 100%;
    position: relative;

    &::after {
      position: absolute;
      z-index: 3;
      right: 0;
      bottom: 0;
      left: 15px;
      height: 1px;
      content: '';
      -webkit-transform: scaleY(0.5);
      transform: scaleY(0.5);
      background-color: #c8c7cc;
    }
  }
}
</style>
