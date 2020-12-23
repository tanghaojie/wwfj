import request from '@/utils/request'

export function get(params) {
  return request({
    url: '/api/services/app/Company/Get',
    method: 'get',
    params
  })
}

export function getAll(params) {
  return request({
    url: '/api/services/app/Company/GetAll',
    method: 'get',
    params
  })
}

export function createCompany(data) {
  return request({
    url: '/api/services/app/Company/Create',
    method: 'post',
    data
  })
}

export function deleteCompany(params) {
  return request({
    url: '/api/services/app/Company/Delete',
    method: 'delete',
    params
  })
}
