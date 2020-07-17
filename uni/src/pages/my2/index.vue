<template>
  <div class="my2 j-flex j-flex-column">
    <div class="top j-flex j-flex-row" @click="loginFormShow">
      <div
        class="ava"
        :style="{ 'background-image': 'url(' + avatarIMGURL + ')' }"
      ></div>
      <div class="username">{{ displayUsername }}</div>
    </div>

    <div
      class="banner"
      :style="{ 'background-image': 'url(' + bannerBGUrl + ')' }"
    >
      <div
        class="logo"
        :style="{ 'background-image': 'url(' + logoBGUrl + ')' }"
      ></div>

      <div class="title">成都市考古勘探发掘项目管理平台</div>

      <div class="steps j-flex j-flex-column j-flex-center">
        <div class="step">资料录入</div>
        <div class="step">考古勘探</div>
        <div class="step">考古发掘</div>
        <div class="step step-none-after">出具文本</div>
      </div>
    </div>

    <div v-if="loginFormShowed" class="login j-flex j-flex-row j-flex-center">
      <div class="content">
        <div class="title">登录</div>
        <div
          class="close j-flex j-flex-row j-flex-center"
          @click="loginFormClose"
        >
          <div class="wrapper">
            <div class="x"></div>
            <div class="x"></div>
          </div>
        </div>

        <div class="form" v-if="!hasLogined">
          <input
            class="input"
            placeholder="请输入用户名或手机号"
            maxlength="16"
            @input="onusernameOrPhoneInput"
            :value="usernameOrPhone"
          />
          <div class="seperate"></div>
          <input
            class="input"
            password="true"
            placeholder="请输入密码"
            maxlength="16"
            @input="onPasswordInput"
            :value="password"
          />
          <div class="register" @click="register">用户注册</div>
          <div class="confirm">
            <button type="primary" @click="login">登录</button>
          </div>
        </div>

        <div class="logined-form" v-if="hasLogined">
          <div class="username">{{ this.$store.state.username }}</div>
          <div class="confirm">
            <button type="warn" @click="logout">退出登录</button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  components: {},
  props: {},
  data() {
    return {
      loginFormShowed: false,
      usernameOrPhone: '',
      password: ''
    }
  },
  computed: {
    bannerBGUrl() {
      return this.BaseUrl + '/imgs/bg1.jpg'
    },
    logoBGUrl() {
      return this.BaseUrl + '/imgs/logo.png'
    },
    avatarIMGURL() {
      return this.BaseUrl + '/imgs/bussiness-man.png'
    },
    workflowBGUrl() {
      return this.BaseUrl + '/imgs/workflow.jpg'
    },
    displayUsername() {
      if (this.$store.state.hasLogin) {
        return this.$store.state.username
      } else {
        return '点击登录'
      }
    },
    hasLogined() {
      return this.$store.state.hasLogin
    }
  },
  watch: {},
  created() {},
  mounted() {},
  methods: {
    loginFormShow() {
      const self = this
      const token = this.$store.state.accessToken
      uni.showLoading({ title: '' })
      uni
        .request({
          url: this.BaseUrl + '/api/services/app/Authentication',
          method: 'GET',
          header: { Authorization: 'Bearer ' + token }
        })
        .then(data => {
          var [error, res] = data
          uni.hideLoading()
          if (error || !res.data.success || !res.data.result) {
            this.$store.dispatch('setLogout')
            console.log('logout')
          } else {
            const user = res.data.result
            this.$store.dispatch('setLogin', user)
            console.log('login')
          }
          self.loginFormShowed = true
        })
    },
    loginFormClose() {
      this.loginFormShowed = false
    },
    login() {
      const self = this
      uni.showLoading({ title: '请稍后...' })
      uni
        .request({
          url: this.BaseUrl + '/api/services/app/Authentication',
          method: 'POST',
          data: {
            usernameOrPhone: this.usernameOrPhone,
            password: this.password
          }
        })
        .then(data => {
          var [error, res] = data
          uni.hideLoading()
          if (error || !res.data.success || !res.data.result) {
            console.log(res)
            uni.showToast({
              title: '登录失败，请重试',
              duration: 1500
            })
            return
          }
          const user = res.data.result
          this.$store.dispatch('setLogin', user)
          console.log('login')
          self.usernameOrPhone = ''
          self.password = ''
          self.loginFormShowed = false
        })
    },
    logout() {
      this.$store.dispatch('setLogout')
    },
    onusernameOrPhoneInput(e) {
      this.usernameOrPhone = e.detail.value
    },
    onPasswordInput(e) {
      this.password = e.detail.value
    },
    register() {
      uni.navigateTo({
        url: 'register'
      })
    }
  }
}
</script>

<style lang="scss" scoped>
.my2 {
  width: 100%;
  height: 100%;
  .top {
    height: 80rpx;
    padding: 6rpx 20rpx;
    background-color: white;
    justify-content: flex-start;
    align-items: center;
    flex: 0 0 auto;

    .ava {
      width: 60rpx;
      height: 60rpx;
      background-position: center;
      background-repeat: no-repeat;
      background-size: contain;
    }

    .username {
      font-size: 28rpx;
      margin-left: 50rpx;
      padding: 10rpx 30rpx;
      background-color: rgb(206, 206, 206);
      border-radius: 20rpx;
    }
  }

  .login {
    position: fixed;
    top: 0;
    bottom: 0;
    left: 0;
    right: 0;
    background-color: rgba(128, 128, 128, 0.5);

    .content {
      min-width: 460rpx;
      background-color: white;
      position: relative;
      border-radius: 20rpx;
      padding: 30rpx 0;

      .title {
        text-align: center;
        font-size: 46rpx;
      }

      .close {
        position: absolute;
        top: 0;
        right: 0;
        width: 100rpx;
        height: 100rpx;
        background-color: transparent;

        .x {
          width: 50rpx;
          height: 4rpx;
          background-color: red;
          position: relative;

          &:nth-child(1) {
            transform: rotate(45deg);
            top: 2rpx;
          }
          &:nth-child(2) {
            transform: rotate(-45deg);
            top: -2rpx;
          }
        }
      }

      .form {
        padding: 26rpx 50rpx;
        .input {
          font-size: 26rpx;
          padding: 26rpx 0rpx;
          position: relative;
        }

        .seperate {
          height: 2rpx;
          width: 100%;
          background-color: rgba(180, 180, 180, 0.658);
        }

        .confirm {
          margin-top: 30rpx;
        }
      }

      .logined-form {
        padding: 26rpx 50rpx;
        .username {
          text-align: center;
        }
        .confirm {
          margin-top: 30rpx;
        }
      }

      .register {
        margin-top: 18rpx;
        font-size: 26rpx;
        color: #007aff;
      }
    }
  }

  .banner {
    flex: 1 0 auto;
    padding: 30rpx;
    background-size: cover;
    background-repeat: no-repeat;
    background-origin: center;
    background-position: center;

    .title {
      margin-top: 160rpx;
      color: #ac1912;
      font-size: 44rpx;
      font-weight: 1000;
      font-family: 'SimSun';
      text-align: center;
      animation: area 2s;
      -webkit-animation: area 2s;
      animation-fill-mode: forwards;
      @keyframes area {
        from {
          transform: scale(0.2);
          opacity: 0.5;
        }
        to {
          transform: scale(1);
          opacity: 1;
        }
      }
    }

    .steps {
      margin-top: 50rpx;
      .step-none-after {
        &::after {
          content: '';
          position: absolute;
          background-color: rgb(0, 122, 255);
          width: unset !important;
          height: unset !important;
          // top: 0;
          bottom: -54rpx;
          left: 120rpx;
          // right: 0;
        }
      }
      .step {
        width: 240rpx;
        padding: 20rpx;
        text-align: center;
        font-size: 32rpx;
        box-sizing: border-box;
        color: rgb(0, 122, 255);
        border: solid 4rpx rgb(0, 122, 255);
        border-radius: 30rpx;
        margin-top: 50rpx;
        position: relative;

        &::after {
          content: '';
          position: absolute;
          background-color: rgb(0, 122, 255);
          width: 6rpx;
          height: 52rpx;
          // top: 0;
          bottom: -54rpx;
          left: 120rpx;
          // right: 0;
        }
      }
    }

    .logo {
      height: 100rpx;
      width: 100%;
      background-size: contain;
      background-repeat: no-repeat;
      background-position: left;
    }
  }

  .workflow {
    height: 1200rpx;
    background-size: contain;
    background-repeat: no-repeat;
    background-position: top;
  }
}
</style>
