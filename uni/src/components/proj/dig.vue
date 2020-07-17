<template>
  <view class="explore-pay">
    <uni-collapse>
      <uni-collapse-item
        title="发掘情况"
        :open="collapseOpen"
        :showAnimation="true"
        :disabled="collapseDisabled"
      >
        <!-- 发掘前期函告时间 -->
        <view class="input-group j-flex j-flex-row ">
          <view class="title">
            <text class="title-text title-text-require">发掘前期函告时间</text>
          </view>
          <view class="input-inline-wrapper">
            <picker
              mode="date"
              :value="letterDateBeforeDig"
              @change="letterDateBeforeDigChange"
              class="text-center"
              :disabled="!formEnable"
            >
              <view class="text-center">{{ letterDateBeforeDig }}</view>
            </picker>
          </view>
        </view>

        <!-- 发掘前期项目现场影响考古入场的实际情况 -->
        <view class="input-group">
          <view class="title"
            ><text class="title-text title-text-require"
              >发掘前期项目现场影响考古入场的实际情况</text
            ></view
          >
          <view class="input-wrapper">
            <checkbox-group
              @change="impactSituationChange"
              class="impactSituationItems"
            >
              <label
                class="j-flex j-flex-row impactSituationItem"
                v-for="item in impactSituationItems"
                :key="item.value"
              >
                <view>
                  <checkbox
                    :value="item.value"
                    :checked="item.checked"
                    :disabled="!formEnable"
                  />
                </view>
                <view>{{ item.name }}</view>
              </label>
            </checkbox-group>
          </view>
        </view>

        <!-- 发掘协议签订时间 -->
        <view class="input-group j-flex j-flex-row ">
          <view class="title">
            <text class="title-text title-text-require">发掘协议签订时间</text>
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

        <!-- 发掘费用缴纳时间 -->
        <view class="input-group j-flex j-flex-row ">
          <view class="title">
            <text class="title-text title-text-require">发掘费用缴纳时间</text>
          </view>
          <view class="input-inline-wrapper">
            <picker
              mode="date"
              :value="digPaidDate"
              @change="digPaidDateChange"
              class="text-center"
              :disabled="!formEnable"
            >
              <view class="text-center">{{ digPaidDate }}</view>
            </picker>
          </view>
        </view>

        <!-- 发掘入场时间 -->
        <view class="input-group j-flex j-flex-row ">
          <view class="title">
            <text class="title-text title-text-require">发掘入场时间</text>
          </view>
          <view class="input-inline-wrapper">
            <picker
              mode="date"
              :value="startDigDate"
              @change="startDigDateChange"
              class="text-center"
              :disabled="!formEnable"
            >
              <view class="text-center">{{ startDigDate }}</view>
            </picker>
          </view>
        </view>

        <!-- 发掘结束时间 -->
        <view class="input-group j-flex j-flex-row ">
          <view class="title">
            <text class="title-text title-text-require">发掘结束时间</text>
          </view>
          <view class="input-inline-wrapper">
            <picker
              mode="date"
              :value="endDigDate"
              @change="endDigDateChange"
              class="text-center"
              :disabled="!formEnable"
            >
              <view class="text-center">{{ endDigDate }}</view>
            </picker>
          </view>
        </view>

        <!-- 发掘阶段性成果报告 -->
        <view class="input-group">
          <view class="title"
            ><text class="title-text title-text-require"
              >发掘阶段性成果报告</text
            ></view
          >
          <view class="input-wrapper">
            <textarea
              auto-height
              @input="stageReportChange"
              :value="stageReport"
              style="margin-top: 10rpx;"
              :disabled="!formEnable"
            />
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
      letterDateBeforeDig: '',
      impactSituationItems: [
        {
          value: 's1',
          name: '情况1'
        },
        {
          value: 's2',
          name: '情况2'
        },
        {
          value: 's3',
          name: '情况3'
        },
        {
          value: 's4',
          name: '情况4'
        },
        {
          value: 's5',
          name: '情况5'
        }
      ],
      protocoledDate: '',
      digPaidDate: '',
      startDigDate: '',
      endDigDate: '',
      stageReport: ''
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
    letterDateBeforeDigChange(e) {
      this.letterDateBeforeDig = e.target.value
    },
    impactSituationChange(e) {
      const impactSituationItems = this.impactSituationItems,
        values = e.detail.value
      for (var i = 0, lenI = impactSituationItems.length; i < lenI; ++i) {
        const item = impactSituationItems[i]
        if (values.includes(item.value)) {
          this.$set(item, 'checked', true)
        } else {
          this.$set(item, 'checked', false)
        }
      }
    },
    protocoledDateChange(e) {
      this.protocoledDate = e.target.value
    },
    digPaidDateChange(e) {
      this.digPaidDate = e.target.value
    },
    startDigDateChange(e) {
      this.startDigDate = e.target.value
    },
    endDigDateChange(e) {
      this.endDigDate = e.target.value
    },
    stageReportChange(e) {
      this.stageReport = e.target.value
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
