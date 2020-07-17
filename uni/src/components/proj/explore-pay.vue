<template>
  <view class="explore-pay">
    <uni-collapse>
      <uni-collapse-item
        title="勘探缴费"
        :open="formEnable"
        :showAnimation="true"
        :disabled="collapseDisabled"
      >
        <!-- 勘探费用缴纳时间 -->
        <view class="input-group j-flex j-flex-row ">
          <view class="title">
            <text class="title-text title-text-require">勘探费用缴纳时间</text>
          </view>
          <view class="input-inline-wrapper">
            <picker
              mode="date"
              :value="explorePaidDate"
              @change="explorePaidDateChange"
              class="text-center"
              :disabled="!formEnable"
            >
              <view class="text-center">{{ explorePaidDate }}</view>
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
  props: {},
  data() {
    return { explorePaidDate: '' }
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
    explorePaidDateChange(e) {
      this.explorePaidDate = e.target.value
    }
  }
}
</script>

<style lang="scss" scoped></style>
