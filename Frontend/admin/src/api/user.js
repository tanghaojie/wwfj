import request from '@/utils/request'

export function login(data) {
  return request({
    url: '/api/services/app/Authentication',
    method: 'post',
    data
  })
}

export function getInfo(token) {
  return request({
    url: '/api/services/app/Authentication',
    method: 'get',
    headers: { Authorization: `Bearer ${token}` }
  })
}

export function getAllUserList(params) {
  return request({
    url: '/api/services/app/User/GetAllUserList',
    method: 'get',
    params
  })
}

export function changeUserLock(data) {
  return request({
    url: '/api/services/app/User/ChangeUserLock',
    method: 'post',
    data
  })
}

export function resetPassword(data) {
  return request({
    url: '/api/services/app/User/ResetPassword',
    method: 'post',
    data
  })
}

export function deleteUser(params) {
  return request({
    url: '/api/services/app/User/DeleteUser',
    method: 'delete',
    params
  })
}
