<template>
  <view class="new">
    <view class="top-space"></view>

    <view class="content">
      <view class="input-group">
        <view class="title">
          <text class="title-text title-text-require ">项目名称</text>
        </view>
        <view class="input-wrapper">
          <input
            class="input"
            @input="onProjNameInput"
            placeholder="请输入项目名称"
          />
        </view>
      </view>

      <view class="input-group j-flex j-flex-row ">
        <view class="title">
          <text class="title-text title-text-require ">所在区域</text>
        </view>
        <view class="input-inline-wrapper">
          <view @click="openAddresPicker" class="text-center">
            {{ locRegion.label }}
          </view>
          <simple-address
            ref="addressPicker"
            themeColor="#007AFF"
            :pickerValueDefault="locRegion.index"
            @onConfirm="onAddresPickerConfirm"
          ></simple-address>
        </view>
      </view>

      <view class="input-group">
        <view class="title"
          ><text class="title-text title-text-require">详细位置</text></view
        >
        <view class="input-wrapper">
          <input
            class="input"
            @input="onLocDetailInput"
            placeholder="请输入详细位置"
          />
        </view>
      </view>

      <view class="input-group j-flex j-flex-row ">
        <view class="title">
          <text class="title-text title-text-require">项目性质</text>
        </view>
        <view class="input-inline-wrapper">
          <picker
            mode="selector"
            :value="projPropIndex"
            :range="projProps"
            range-key="name"
            class="text-center"
            @change="onProjPropChange"
          >
            <view class="">{{ projProps[projPropIndex].name }}</view>
          </picker>
        </view>
      </view>

      <view class="input-group j-flex j-flex-row ">
        <view class="title">
          <text class="title-text title-text-require">用地性质</text>
        </view>
        <view class="input-inline-wrapper">
          <picker
            mode="selector"
            :value="landPropIndex"
            :range="landProps"
            range-key="name"
            class="text-center"
            @change="onLandPropChange"
          >
            <view class="">{{ landProps[landPropIndex].name }}</view>
          </picker>
        </view>
      </view>
    </view>

    <button class="share-button .j-theme-bg" @click="onCommit">提交</button>
  </view>
</template>

<script>
import simpleAddress from '@/components/simple-address/simple-address.vue'

export default {
  name: '',
  data() {
    return {}
  },
  components: {
    simpleAddress
  },
  computed: {},
  watch: {},
  methods: {
    getData() {
      uni.showLoading({
        title: ''
      })
      uni
        .request({
          url: this.BaseUrl + '/api/services/app/FJ/Get',
          method: 'GET',
          data: {
            id: this.id
          }
        })
        .then(data => {
          var [error, res] = data
          uni.hideLoading()
          if (error) {
            uni.showToast({
              title: '获取数据失败，点击重试',
              duration: 1500
            })
            return
          }
          uni.navigateBack({
            success: function() {
              uni.startPullDownRefresh()
            }
          })
          // console.log(error)
          // console.log(res)
        })
    }
  },
  props: {
    id: {
      type: Number,
      required: true
    }
  },
  mounted() {}
}
</script>

<style lang="scss" scoped>
.new {
  background-color: #ddd;
  height: 100vh;
  font-size: 34rpx;

  .top-space {
    height: 1rpx;
  }

  .content {
    .input-group {
      margin: 30rpx 0;
      background-color: #ffffff;
      padding: 10rpx 16rpx;

      .title {
        .title-text {
          font-size: 34rpx;
          color: #222;
        }
      }
      .input-inline-wrapper {
        flex-grow: 1;
        display: flex;
        flex-direction: row;
        flex-wrap: nowrap;

        .text-center {
          height: 48rpx;
          font-size: 34rpx;
          flex: 1;
          width: 100%;
          text-align: center;
        }
      }
      .input-wrapper {
        margin-top: 15rpx;
        display: flex;
        flex-direction: row;
        flex-wrap: nowrap;

        .input {
          height: 48rpx;
          font-size: 32rpx;
          flex: 1;
        }
      }
    }
  }

  .share-button {
    color: #fff;
  }
}
</style>
