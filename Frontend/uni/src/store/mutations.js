import {
  HAS_LOGIN,
  USERNAME,
  USER_ID,
  PHONE,
  REAL_NAME,
  ACCESS_TOKEN,
  LOGIN,
  LOGOUT
} from './mutation-types.js'
import { USER_INFO } from './storage-keys.js'

export default {
  [HAS_LOGIN](state, value) {
    if (value) {
      state.hasLogin = value
    } else {
      state.hasLogin = false
    }
  },
  [USERNAME](state, value) {
    if (value) {
      state.username = value
    } else {
      state.username = null
    }
  },
  [USER_ID](state, value) {
    if (value) {
      state.userID = value
    } else {
      state.userID = null
    }
  },
  [PHONE](state, value) {
    if (value) {
      state.phone = value
    } else {
      state.phone = null
    }
  },
  [REAL_NAME](state, value) {
    if (value) {
      state.realname = value
    } else {
      state.realname = null
    }
  },
  [ACCESS_TOKEN](state, value) {
    if (value) {
      state.accessToken = value
    } else {
      state.accessToken = null
    }
  },
  [LOGIN](state, user) {
    state.hasLogin = true
    state.username = user.username || null
    state.userID = user.userId || null
    state.phone = user.phone || null
    state.realname = user.realname || null
    state.accessToken = user.accessToken || null
    // state.role = user.role || null
    state.regionCode = user.regionCode || null
    state.regionName = user.regionName || null
    state.regionIndex = user.regionIndex || null
    state.department = user.department
    uni.setStorage({
      key: USER_INFO,
      data: user
    })
  },
  [LOGOUT](state) {
    state.hasLogin = false
    state.username = null
    state.userID = null
    state.phone = null
    state.realname = null
    state.accessToken = null
    // state.role = null
    state.regionCode = null
    state.regionName = null
    state.regionIndex = null
    state.department = null
    uni.removeStorage({
      key: USER_INFO
    })
  }
}
