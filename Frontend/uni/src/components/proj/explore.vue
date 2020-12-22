<template>
  <view class="explore">
    <uni-collapse>
      <uni-collapse-item
        title="勘探信息"
        :open="collapseOpen"
        :showAnimation="true"
        :disabled="collapseDisabled"
      >
        <!-- 勘探入场时间 -->
        <view class="input-group j-flex j-flex-row ">
          <view class="title">
            <text class="title-text title-text-require">勘探入场时间</text>
          </view>
          <view class="input-inline-wrapper">
            <picker
              mode="date"
              :value="exploreStartDate"
              @change="exploreStartDateChange"
              class="text-center"
              :disabled="!formEnable"
            >
              <view class="text-center">{{ exploreStartDate }}</view>
            </picker>
          </view>
        </view>

        <!-- 勘探结束时间 -->
        <view class="input-group j-flex j-flex-row ">
          <view class="title">
            <text class="title-text title-text-require">勘探结束时间</text>
          </view>
          <view class="input-inline-wrapper">
            <picker
              mode="date"
              :value="exploreEndDate"
              @change="exploreEndDateChange"
              class="text-center"
              :disabled="!formEnable"
            >
              <view class="text-center">{{ exploreEndDate }}</view>
            </picker>
          </view>
        </view>

        <!-- 项目现场文勘条件 -->
        <view class="input-group">
          <view class="title">
            <text class="title-text title-text-require ">项目现场文勘条件</text>
          </view>
          <view class="input-wrapper">
            <input
              class="input"
              @input="exploreConditionChange"
              type="digit"
              placeholder="请输入..."
              :value="exploreCondition"
              :disabled="!formEnable"
            />
          </view>
        </view>

        <!-- 是否转入考古发掘 -->
        <view class="input-group j-flex j-flex-row ">
          <view class="title">
            <text class="title-text title-text-require">是否转入考古发掘</text>
          </view>
          <view class="input-inline-wrapper m-l-30">
            <switch
              :checked="ifDig"
              type="checkbox"
              @change="digChange"
              :disabled="!formEnable"
            />
          </view>
        </view>

        <!-- 以下转入考古发掘 -->
        <view v-show="ifDig">
          <!-- 遗存发现基本情况 -->
          <view class="input-group">
            <view class="title">
              <text class="title-text title-text-require "
                >遗存发现基本情况</text
              >
            </view>
            <view class="input-wrapper">
              <input
                class="input"
                @input="onSituationInput"
                placeholder="请输入..."
                :value="situation"
                :disabled="!formEnable"
              />
            </view>
          </view>

          <!-- 预计发掘面积 -->
          <view class="input-group j-flex j-flex-row">
            <view class="title">
              <text class="title-text title-text-require ">预计发掘面积</text>
            </view>
            <view class="input-inline-wrapper">
              <picker
                mode="selector"
                :value="estimateDigAreaIndex"
                :range="estimateDigAreas"
                range-key="name"
                class="text-center"
                @change="unEstimateDigAreaChange"
                :disabled="!formEnable"
              >
                <view class="text-center">{{
                  estimateDigAreas[estimateDigAreaIndex].name
                }}</view>
              </picker>
            </view>
          </view>

          <!-- 预计发掘周期 -->
          <view class="input-group">
            <view class="title">
              <text class="title-text title-text-require">预计发掘周期</text>
            </view>
            <view class="input-wrapper">
              <input
                class="input"
                @input="onEstimateTimespanInput"
                placeholder="请输入..."
                :value="estimateTimespan"
                :disabled="!formEnable"
              />
            </view>
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
      exploreStartDate: '',
      exploreEndDate: '',
      exploreCondition: '',
      ifDig: false,
      situation: '',
      estimateTimespan: '',
      estimateDigAreaIndex: 0,
      estimateDigAreas: [
        { name: '0-500m²' },
        { name: '500m²-1000m²' },
        { name: '1000m²-2000m²' }
      ]
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
    formEnable: {
      type: Boolean,
      default: true
    }
  },
  computed: {},
  watch: {},
  created() {},
  mounted() {},
  methods: {
    exploreStartDateChange(e) {
      this.exploreStartDate = e.target.value
    },
    exploreEndDateChange(e) {
      this.exploreEndDate = e.target.value
    },
    exploreConditionChange(e) {
      this.exploreCondition = e.target.value
    },
    digChange(e) {
      this.ifDig = e.target.value
    },
    onSituationInput(e) {
      this.situation = e.target.value
    },
    unEstimateDigAreaChange(e) {
      this.estimateDigAreaIndex = e.target.value
    },
    onEstimateTimespanInput(e) {
      this.estimateTimespan = e.target.value
    }
  }
}
</script>

<style lang="scss" scoped></style>
