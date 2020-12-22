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

export default {
  setHasLogin(context, value) {
    context.commit(HAS_LOGIN, value)
  },
  setUsername(context, value) {
    context.commit(USERNAME, value)
  },
  setUserID(context, value) {
    context.commit(USER_ID, value)
  },
  setPhone(context, value) {
    context.commit(PHONE, value)
  },
  setRealname(context, value) {
    context.commit(REAL_NAME, value)
  },
  setAccessToken(context, value) {
    context.commit(ACCESS_TOKEN, value)
  },
  setLogin(context, user) {
    context.commit(LOGIN, user)
  },
  setLogout(context) {
    context.commit(LOGOUT)
  }
}
