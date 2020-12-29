import Vue from 'vue'
import 'weapp-cookie'
import store from './store/store'
import App from './App'

Vue.config.productionTip = false

Vue.prototype.$store = store
// Vue.prototype.BaseUrl = 'http://117.139.247.104:60001/wwfjapi'
// Vue.prototype.BaseUrl = 'http://117.139.247.104:60001/wwfjapi_test'
Vue.prototype.BaseUrl = 'http://117.139.247.104:60001/wwfj-v2-backend'
// Vue.prototype.BaseUrl = 'http://localhost:12345/wwfjapi'
Vue.prototype.State = {
  New: 0, //已新建项目
  UnProtocoled: 1, //未签订协议  finished
  Protocoled: 2, //已经提交资料签订了协议，未缴费
  Exploring: 3, //已缴费，勘探中
  UnDig: 4, // 勘探完成，不转考古 finish
  Diging: 5, // 勘探完成，转考古
  Diged: 6 // 考古发掘完成 finish
}
Vue.prototype.Department = {
  KanTanYeWu: 0,
  KanTanBan: 1,
  FaJueXianChangeFuZeRen: 2,
  WenBaoChu: 3,
  Other: 4
}
Vue.prototype.getYMD = function(strDate) {
  const date = strDate ? new Date(strDate) : new Date()
  let year = date.getFullYear()
  let month = date.getMonth() + 1
  let day = date.getDate()
  month = month > 9 ? month : '0' + month
  day = day > 9 ? day : '0' + day
  return `${year}-${month}-${day}`
}

App.mpType = 'app'

const app = new Vue({
  store,
  ...App
})
app.$mount()
