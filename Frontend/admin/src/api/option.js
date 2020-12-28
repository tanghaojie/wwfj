import request from '@/utils/request'

export function getByType(params) {
  return request({
    url: '/api/services/app/Option/GetByType',
    method: 'get',
    params
  })
}

export function update(data) {
  return request({
    url: '/api/services/app/Option/Update',
    method: 'put',
    data
  })
}
