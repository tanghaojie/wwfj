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
