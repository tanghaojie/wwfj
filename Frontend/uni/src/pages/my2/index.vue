<template>
  <div class="my2 j-flex j-flex-column">
    <div class="top">
      <div class="left j-flex j-flex-row" @click="loginFormShow">
        <div
          class="ava"
          :style="{ 'background-image': 'url(' + avatarIMGURL + ')' }"
        ></div>
        <div class="username">{{ displayUsername }}</div>
      </div>
      <!-- <div class="right" @click="settingPage">
        <div class="setting">
          <svg
            t="1597728650238"
            class="icon"
            viewBox="0 0 1024 1024"
            version="1.1"
            xmlns="http://www.w3.org/2000/svg"
            p-id="2667"
            width="32"
            height="32"
          >
            <path
              d="M512 640c-70.592 0-128-57.408-128-128s57.408-128 128-128 128 57.408 128 128-57.408 128-128 128m0-320a192 192 0 0 0 0 384 192 192 0 0 0 0-384"
              fill="#202020"
              p-id="2668"
            ></path>
            <path
              d="M693.216 735.552a291.744 291.744 0 0 1-40.512 27.52c-1.216 0.64-2.368 1.472-3.616 2.144a286.08 286.08 0 0 1-34.048 15.392l-19.552 72.992-9.28 34.592c-0.576 0.128-1.152 0.32-1.76 0.384l-8.736 1.632c-3.52 0.64-7.104 1.088-10.656 1.6a357.152 357.152 0 0 1-53.056 3.744c-5.216 0-10.464-0.128-15.68-0.32l-8.64-0.48a355.936 355.936 0 0 1-28.736-2.944c-3.52-0.512-7.072-0.96-10.624-1.6a418.496 418.496 0 0 1-8.736-1.6l-1.76-0.416-9.28-34.56-19.584-73.024a286.784 286.784 0 0 1-47.84-23.776 287.488 287.488 0 0 1-30.304-21.28l-72.96 19.552-34.56 9.28-1.184-1.376a237.504 237.504 0 0 1-5.792-6.72c-2.304-2.784-4.512-5.664-6.752-8.512a315.84 315.84 0 0 1-16.928-23.424c-1.6-2.336-3.104-4.768-4.64-7.168a337.92 337.92 0 0 1-15.68-27.168 435.84 435.84 0 0 1-3.936-7.68c-1.536-3.104-3.072-6.208-4.512-9.344a362.912 362.912 0 0 1-7.296-17.024c-1.344-3.328-2.688-6.656-3.968-9.984l-2.976-8.448-0.512-1.696 25.184-25.184 53.568-53.632a292.8 292.8 0 0 1-3.68-41.28c0-1.28-0.192-2.496-0.192-3.744 0-1.28 0.192-2.464 0.192-3.744a292.8 292.8 0 0 1 3.68-41.28l-53.568-53.632-25.184-25.184a438.656 438.656 0 0 1 3.488-10.144c1.28-3.36 2.624-6.688 3.968-10.048a375.68 375.68 0 0 1 52.992-91.776c2.24-2.848 4.448-5.696 6.72-8.48 1.92-2.24 3.84-4.48 5.824-6.72l1.184-1.376 34.56 9.28 72.96 19.52c9.568-7.776 19.744-14.72 30.304-21.28l4.064-2.464a283.68 283.68 0 0 1 43.776-21.28l19.584-73.024 9.28-34.56 1.76-0.416c2.88-0.544 5.76-1.12 8.704-1.6 3.52-0.608 7.168-1.12 10.752-1.6 6.08-0.864 12.16-1.6 18.336-2.208a362.752 362.752 0 0 1 19.008-1.184c5.184-0.224 10.4-0.384 15.616-0.384 5.216 0 10.464 0.16 15.648 0.384a362.752 362.752 0 0 1 19.008 1.184c6.08 0.576 12.224 1.344 18.304 2.24 3.616 0.448 7.2 0.96 10.784 1.536l8.704 1.632 1.76 0.384 9.28 34.592 19.52 72.992c11.712 4.512 23.168 9.472 34.08 15.392 1.248 0.672 2.4 1.504 3.616 2.176 14.304 8.064 27.84 17.216 40.512 27.52l72.96-19.584 34.528-9.248 1.216 1.344c1.92 2.24 3.904 4.48 5.76 6.752 2.304 2.752 4.48 5.632 6.72 8.448 3.84 4.864 7.552 9.792 11.136 14.848 1.984 2.816 3.904 5.696 5.824 8.544l4.672 7.232a357.472 357.472 0 0 1 19.616 34.88 397.184 397.184 0 0 1 11.776 26.336c1.344 3.328 2.72 6.656 4 10.048 1.024 2.784 1.984 5.568 2.944 8.384 0.192 0.576 0.32 1.152 0.544 1.728l-25.184 25.184-53.6 53.6c1.92 12.064 3.104 24.352 3.488 36.896 0.064 2.72 0.384 5.44 0.384 8.16 0 2.752-0.32 5.44-0.384 8.16a291.136 291.136 0 0 1-3.52 36.864l53.632 53.632 25.184 25.184-0.544 1.696c-0.96 2.816-1.92 5.6-2.944 8.384-1.28 3.392-2.624 6.72-4 10.08a376.32 376.32 0 0 1-11.776 26.336 435.84 435.84 0 0 1-11.456 21.44c-2.624 4.544-5.376 8.992-8.16 13.44-1.536 2.368-3.072 4.8-4.64 7.136a315.84 315.84 0 0 1-16.96 23.456c-2.24 2.88-4.48 5.696-6.72 8.448-1.92 2.304-3.84 4.512-5.792 6.752-0.384 0.48-0.8 0.896-1.216 1.344l-34.56-9.248-72.96-19.52z m-305.12 139.328c-2.624-0.896-5.28-1.728-7.872-2.688l-3.328-1.216-3.328-1.28c4.896 1.92 9.856 3.584 14.816 5.248l-0.32-0.064z m-119.424-66.368l-2.656-2.24c-2.144-1.824-4.224-3.712-6.336-5.568l-0.224-0.192c3.968 3.52 7.936 6.976 12.064 10.272l-2.88-2.24z m623.776-245.664l-0.192-0.16-0.096-0.128h-0.032l-29.184-29.216c0.416-7.104 1.056-14.144 1.056-21.344 0-7.232-0.64-14.272-1.056-21.376l29.184-29.184 0.128-0.128 0.192-0.192 54.72-54.72a444.032 444.032 0 0 0-18.4-57.376 449.664 449.664 0 0 0-28.8-61.024c-11.424-19.84-24.576-38.08-38.432-55.456a449.024 449.024 0 0 0-40.48-44.64l-74.752 20.032-0.064 0.032-0.224 0.064-0.16 0.032h-0.032l-39.424 10.56a348.448 348.448 0 0 0-37.472-21.376l-10.624-39.68-0.032-0.064-0.032-0.16-0.064-0.224v-0.064l-20.032-74.752a447.68 447.68 0 0 0-58.88-12.736A448.128 448.128 0 0 0 512 64c-22.912 0-45.248 2.24-67.232 5.568-20.096 3.04-39.776 7.136-58.88 12.736l-20.032 74.752-0.032 0.064-0.064 0.224-0.032 0.16v0.064l-10.656 39.68c-12.928 6.464-25.504 13.472-37.472 21.44l-39.392-10.56-0.064-0.064h-0.16l-0.224-0.096h-0.064l-74.72-20.064c-14.432 13.76-27.84 28.8-40.48 44.64A446.816 446.816 0 0 0 124.032 288c-11.456 19.84-20.672 40.32-28.8 61.024A450.496 450.496 0 0 0 76.8 406.4l54.72 54.72v0.064l0.224 0.16 0.096 0.128v0.032l29.216 29.184C160.64 497.76 160 504.8 160 512c0 7.2 0.64 14.208 1.088 21.312l-29.184 29.184-0.032 0.032-0.096 0.128-0.192 0.192-0.032 0.032L76.8 617.6c4.704 19.328 11.008 38.464 18.4 57.344 8.128 20.704 17.344 41.216 28.8 61.056 11.456 19.84 24.576 38.08 38.464 55.424 12.672 15.872 26.048 30.88 40.48 44.64l74.72-20.032h0.064l0.224-0.064 0.16-0.064h0.064l39.36-10.56c12 7.936 24.576 14.912 37.504 21.376l10.656 39.712v0.224l0.096 0.224v0.032l20.064 74.752c19.104 5.6 38.784 9.728 58.88 12.736a447.68 447.68 0 0 0 67.2 5.6c22.976 0 45.28-2.24 67.296-5.6a442.56 442.56 0 0 0 58.88-12.736l20.032-74.752 0.064-0.256 0.064-0.192 10.624-39.68c12.928-6.496 25.504-13.504 37.44-21.44l39.456 10.56v0.032l0.192 0.032 0.224 0.064h0.064l74.752 20.032c14.4-13.76 27.808-28.768 40.48-44.64A449.92 449.92 0 0 0 900 736c11.456-19.84 20.64-40.32 28.768-61.056 7.424-18.88 13.728-37.984 18.432-57.344l-54.72-54.72h-0.032z"
              fill="#202020"
              p-id="2669"
            ></path>
          </svg>
        </div>
      </div> -->
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
              title: '登录失败，请重试，或账号处于锁定状态',
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
    },
    settingPage() {
      uni.navigateTo({
        url: 'setting'
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
    display: flex;
    flex-direction: row;
    justify-content: space-between;
    align-items: center;
    flex: 0 0 auto;

    .left {
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

    .right {
      height: 100%;
      .setting {
        height: 100%;
        display: flex;
        justify-content: center;
        align-items: center;
      }
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
