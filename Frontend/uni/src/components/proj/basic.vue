<template>
  <view class="new">
    <simple-address
      ref="addressPicker"
      themeColor="#007AFF"
      :pickerValueDefault="locRegion.index"
      @onConfirm="onAddresPickerConfirm"
    ></simple-address>
    <uni-collapse>
      <uni-collapse-item
        title="基本信息"
        :open="collapseOpen"
        :showAnimation="true"
        :disabled="collapseDisabled"
      >
        <!-- 项目名称 -->
        <view class="input-group">
          <view class="title">
            <text class="title-text title-text-require ">项目名称</text>
          </view>
          <view class="input-wrapper">
            <input
              class="input"
              @input="onProjNameInput"
              placeholder="请输入项目名称"
              :value="projName"
              :disabled="!formEnable"
            />
          </view>
        </view>

        <!-- 委托单位 -->
        <view class="input-group j-flex j-flex-row ">
          <view class="title">
            <text class="title-text">委托单位</text>
          </view>
          <view class="input-inline-wrapper">
            <picker
              mode="selector"
              :value="requesterIndex"
              :range="requesters"
              :disabled="!formEnable"
              range-key="name"
              class="text-center"
              @change="onrequesterChange"
            >
              <view class="">{{ requesters[requesterIndex].name }}</view>
            </picker>
          </view>
        </view>

        <!-- 所在区域 -->
        <view class="input-group j-flex j-flex-row ">
          <view class="title">
            <text class="title-text title-text-require ">所在区域</text>
          </view>
          <view class="input-inline-wrapper">
            <view @click="openAddresPicker" class="text-center">
              {{ locRegion.label }}
            </view>
          </view>
        </view>

        <!-- 详细位置 -->
        <view class="input-group">
          <view class="title"
            ><text class="title-text title-text-require">详细位置</text></view
          >
          <view class="input-wrapper">
            <input
              class="input"
              @input="onLocDetailInput"
              placeholder="请输入详细位置"
              :value="locDetail"
              :disabled="!formEnable"
            />
          </view>
        </view>

        <!-- 项目性质 -->
        <view class="input-group j-flex j-flex-row ">
          <view class="title">
            <text class="title-text">项目性质</text>
          </view>
          <view class="input-inline-wrapper">
            <picker
              mode="selector"
              :value="projPropIndex"
              :range="projProps"
              :disabled="!formEnable"
              range-key="name"
              class="text-center"
              @change="onProjPropChange"
            >
              <view class="">{{ projProps[projPropIndex].name }}</view>
            </picker>
          </view>
        </view>

        <!-- 用地性质 -->
        <view class="input-group j-flex j-flex-row ">
          <view class="title">
            <text class="title-text">用地性质</text>
          </view>
          <view class="input-inline-wrapper">
            <picker
              mode="selector"
              :value="landPropIndex"
              :range="landProps"
              :disabled="!formEnable"
              range-key="name"
              class="text-center"
              @change="onLandPropChange"
            >
              <view class="">{{ landProps[landPropIndex].name }}</view>
            </picker>
          </view>
        </view>
      </uni-collapse-item>
    </uni-collapse>
  </view>
</template>

<script>
import simpleAddress from '@/components/simple-address/simple-address.vue'
import uniCollapse from '@/components/uni-collapse/uni-collapse.vue'
import uniCollapseItem from '@/components/uni-collapse-item/uni-collapse-item.vue'

export default {
  components: { simpleAddress, uniCollapse, uniCollapseItem },
  props: {
    collapseOpen: {
      type: Boolean,
      default: false
    },
    collapseDisabled: {
      type: Boolean,
      default: false
    },
    formEnable: {
      type: Boolean,
      default: true
    },
    locRegionEnable: {
      type: Boolean,
      default: true
    }
  },
  data() {
    return {
      projName: '',
      locRegion: {
        label: '',
        index: [22, 0, 0],
        code: ''
      },
      locDetail: null,
      projPropIndex: 0,
      projProps: [
        { name: '' },
        { name: '国家' },
        { name: '省级' },
        { name: '市级' },
        { name: '区级重点' },
        { name: '一般项目' }
      ],
      landPropIndex: 0,
      landProps: [
        { name: '' },
        { name: '上市' },
        { name: '协议出让' },
        { name: '划拨' },
        { name: '自由土地' }
      ],
      requesterIndex: 0,
      requesters: []
    }
  },
  computed: {},
  watch: {},
  created() {},
  mounted() {
    this.getRequestCompanies()
  },
  methods: {
    onProjNameInput(e) {
      this.projName = e.detail.value
    },
    onLocDetailInput(e) {
      this.locDetail = e.detail.value
    },
    onLandPropChange(e) {
      this.landPropIndex = e.detail.value
    },
    onProjPropChange(e) {
      this.projPropIndex = e.detail.value
    },
    onrequesterChange(e) {
      this.requesterIndex = e.detail.value
    },
    openAddresPicker() {
      if (!this.formEnable || !this.locRegionEnable) {
        return
      }
      this.$refs.addressPicker.open()
    },
    onAddresPickerConfirm(e) {
      this.locRegion.label = e.label
      this.locRegion.index = e.value
      this.locRegion.code = e.areaCode
    },
    getRequestCompanies() {
      uni.showLoading({ title: '' })
      uni
        .request({
          url: this.BaseUrl + '/api/services/app/RequestCompany/GetAllList',
          method: 'GET'
        })
        .then(data => {
          uni.hideLoading()
          var [error, res] = data
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
          this.requesters = res.data.result
        })
    }
  }
}
</script>
