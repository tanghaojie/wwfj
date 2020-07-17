<template>
  <view class="j-full-screen">
    <view
      v-if="userInfo"
      class="user j-flex j-flex-column j-flex-center j-h-100 h-w-100"
    >
      <view>
        <image :src="userInfo.avatarUrl"></image>
      </view>
      <view>{{ userInfo.nickName || userInfo.email }}</view>
    </view>
    <view v-else class="j-flex j-flex-column j-flex-center j-h-100 j-w-100">
      <!-- #ifdef APP-PLUS || MP-ALIPAY || MP-TOUTIAO -->
      <!-- <button type="primary" @click="getUserInfo">获取用户信息</button> -->
      <!-- #endif -->
      <!-- #ifdef MP-WEIXIN || MP-BAIDU || MP-QQ -->
      <button
        type="primary"
        open-type="getUserInfo"
        @getuserinfo="mpGetUserInfo"
        class="j-w-100"
      >
        点击授权登录
      </button>
      <!-- #endif -->
    </view>
  </view>
</template>

<script>
import { mapActions, mapMutations } from 'vuex'

export default {
  components: {},
  props: {},
  data() {
    return {
      userInfo: null
    }
  },
  watch: {},
  computed: {},
  methods: {
    ...mapActions({
      setHasLogin: 'setHasLogin',
      setLoginProvider: 'setLoginProvider'
    }),
    init() {
      const self = this
      wx.getSetting({
        success(res) {
          console.log(res.authSetting)
          if (res.authSetting['scope.userInfo']) {
            wx.getUserInfo({
              success: res => {
                console.log(res)
                self.userInfo = res.userInfo
              },
              fail: res => {
                self.userInfo = null
              }
            })
          }
        }
      })
    },
    mpGetUserInfo(result) {
      if (result.detail.errMsg !== 'getUserInfo:ok') {
        uni.showModal({
          title: '获取用户信息失败',
          content: '错误原因' + result.detail.errMsg,
          showCancel: false
        })
        return
      }
      console.log('mpGetUserInfo', result)
      this.userInfo = result.detail.userInfo
    }
  },
  created() {},
  mounted() {
    this.init()
  }
}
</script>

<style lang="scss" scoped>
.user {
  image {
    border-radius: 128rpx;
    width: 128rpx;
    height: 128rpx;
  }
}
</style>
