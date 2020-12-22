<script>
import { USER_INFO } from './store/storage-keys.js'
import './common/util.scss'

export default {
  onLaunch: function() {
    uni.showLoading({ title: '' })
    let token = ''
    try {
      const user = uni.getStorageSync(USER_INFO)
      if (user) {
        this.$store.dispatch('setLogin', user)
        token = user.accessToken || ''
      }
    } catch (e) {
      console.log('Get storage error: ', e)
    }
    uni
      .request({
        url: this.BaseUrl + '/api/services/app/Authentication',
        method: 'GET',
        header: {
          Authorization: 'Bearer ' + token
        }
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
      })
  },
  onShow: function() {
    // console.log('App Show')
  },
  onHide: function() {
    // console.log('App Hide')
  },
  onError(err) {
    console.error(err)
  }
}
</script>

<style>
/*每个页面公共css */
page {
  height: 100%;
}
</style>
