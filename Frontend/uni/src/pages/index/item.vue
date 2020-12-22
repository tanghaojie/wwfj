<template>
  <view class="item">
    <view class="wrapper">
      <view class="title j-flex j-flex-row">
        <view>
          <text>{{ title.left }}</text></view
        >
        <view class="title-status" v-if="title.right">
          <text>{{ title.right }}</text></view
        >
      </view>
      <view class="content">
        <view :key="row" v-for="row in content" class="row"
          ><text>{{ row }}</text></view
        >
      </view>
      <view class="bottom j-flex j-flex-row"
        ><view>
          <text>{{ bottom.left }}</text></view
        >
        <view v-if="bottom.right">
          <text>{{ bottom.right }}</text></view
        ></view
      >
    </view>
  </view>
</template>

<script>
export default {
  components: {},
  props: {
    title: {
      type: Object,
      required: true,
      default: {
        left: '',
        right: null
      }
    },
    content: {
      type: Array,
      default: []
    },
    bottom: {
      type: Object,
      required: true,
      default: {
        left: '',
        right: null
      }
    }
  },
  data() {
    return {}
  },
  watch: {},
  computed: {},
  methods: {},
  created() {},
  mounted() {}
}
</script>

<style lang="scss" scoped>
.item {
  background-color: white;
  border-bottom-width: 2rpx;
  border-bottom-color: gray;
  border-bottom-style: solid;
  font-size: 34rpx;

  .wrapper {
    padding: 20rpx 50rpx;

    .title {
      justify-content: space-between;
      padding: 5rpx 0;

      .title-status {
        padding: 5rpx 20rpx;
        font-size: 28rpx;
        color: rgb(0, 122, 255);
        border: solid 1rpx rgb(0, 122, 255);
        border-radius: 10rpx;
      }
    }

    .content {
      min-height: 38rpx;
      font-size: 32rpx;
      color: #555;

      .row {
        margin: 6rpx 0;
      }
    }

    .bottom {
      margin-top: 20rpx;
      justify-content: space-between;
      font-size: 26rpx;
      color: #888;
    }
  }
}
</style>
