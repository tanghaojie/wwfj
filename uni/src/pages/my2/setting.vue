<template>
  <div class="setting">
    <div class="users">
      <div class="user j-flex j-flex-row" v-for="user in users" :key="user.id">
        <div
          class="ava"
          :style="{ 'background-image': 'url(' + avatarIMGURL + ')' }"
        ></div>

        <div class="content">
          <div class="username">{{ user.username }}</div>
          <div class="container j-flex j-flex-row">
            <div class="realname">{{ user.realname }}</div>
            <div class="phone">{{ user.phone }}</div>
          </div>
          <div class="department">{{ user.departmentStr }}</div>
          <div class="region">{{ user.regionName }}</div>
        </div>

        <div class="lock" @click="setLock(user)">
          <svg
            v-if="user.locked"
            t="1597732087868"
            class="icon"
            viewBox="0 0 1024 1024"
            version="1.1"
            xmlns="http://www.w3.org/2000/svg"
            p-id="2666"
            width="38"
            height="38"
          >
            <path
              d="M714.368 759.616L264.352 309.6c13.536-16.544 28.736-31.68 45.28-45.248l449.984 450.016c-13.536 16.544-28.704 31.68-45.248 45.248M512 64C264.544 64 64 264.576 64 512s200.544 448 448 448c247.424 0 448-200.576 448-448S759.424 64 512 64"
              fill="#d81e06"
              p-id="2667"
            ></path>
          </svg>
          <svg
            v-else
            t="1597732191722"
            class="icon"
            viewBox="0 0 1024 1024"
            version="1.1"
            xmlns="http://www.w3.org/2000/svg"
            p-id="3334"
            width="38"
            height="38"
          >
            <path
              d="M805.056 759.808L264.192 218.912A382.24 382.24 0 0 1 512 128.032c212.064 0 384 171.872 384 384 0 94.464-34.24 180.896-90.944 247.776M128 512a382.08 382.08 0 0 1 90.944-247.84l540.864 540.896A381.984 381.984 0 0 1 512 896C299.936 896 128 724.064 128 512M512 64C264.96 64 64 264.96 64 512s200.96 448 448 448 448-200.96 448-448S759.04 64 512 64"
              fill="#e6e6e6"
              p-id="3335"
            ></path>
          </svg>
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
      users: []
    }
  },
  computed: {
    avatarIMGURL() {
      return this.BaseUrl + '/imgs/bussiness-man.png'
    }
  },
  watch: {},
  created() {},
  mounted() {
    this.getUsers()
  },
  methods: {
    getUsers() {
      uni.showLoading({
        title: '加载中'
      })
      this.users = []
      uni
        .request({
          url: this.BaseUrl + '/api/services/app/User'
        })
        .then(data => {
          var [error, res] = data
          let errorText = null
          uni.hideLoading()
          uni.stopPullDownRefresh()
          if (error || !res.data.success) {
            let text = '获取数据失败，请重试'
            if (res && res.data && res.data.error && res.data.error.message) {
              text = res.data.error.message
            }
            uni.showToast({
              title: text,
              duration: 1500
            })
            return
          }
          const users = []
          let content = res.data
          this.users = content.result
        })
    },
    setLock(user) {
      uni.showLoading({ title: '' })
      uni
        .request({
          url: this.BaseUrl + '/api/services/app/User/ChangeUserLock',
          method: 'POST',
          data: {
            locked: !user.locked,
            id: user.id
          },
          header: {
            'content-type': 'application/json'
          }
        })
        .then(data => {
          var [error, res] = data
          uni.hideLoading()
          if (error || !res.data.success || res.statusCode !== 200) {
            let text = '网络请求失败，请刷新页面后重试'
            if (res && res.data && res.data.error && res.data.error.message) {
              text = res.data.error.message
            }
            uni.showToast({
              title: text,
              duration: 1500
            })
            return
          }
          user.locked = !user.locked
        })
    }
  },
  onPullDownRefresh() {
    this.getUsers()
  }
}
</script>

<style lang="scss" scoped>
.setting {
  .users {
    .user {
      padding: 22rpx;
      align-items: center;
      border-bottom: solid #000 2rpx;

      .ava {
        width: 60rpx;
        height: 60rpx;
        background-position: center;
        background-repeat: no-repeat;
        background-size: contain;
      }
      .content {
        margin-left: 20rpx;
        flex: 1 1 auto;

        .username {
          font-size: 1rem;
        }
        .container {
          font-size: 0.8rem;
          margin-top: 12rpx;
          color: #505050;

          .realname {
          }

          .phone {
          }
        }
        .department {
          font-size: 0.8rem;
          color: #505050;
        }
        .region {
          font-size: 0.8rem;
          color: #505050;
        }
      }

      .lock {
        height: 100%;
      }
    }
  }
}
</style>
