import request from '@/utils/request'

export function get(params) {
  return request({
    url: '/api/services/app/FJ2/Get',
    method: 'get',
    params
  })
}

export function getAllList(params) {
  return request({
    url: '/api/services/app/FJ2/GetAllList',
    method: 'get',
    params
  })
}

export function deleteRelic(params) {
  return request({
    url: '/api/services/app/FJ2/Delete',
    method: 'delete',
    params
  })
}
