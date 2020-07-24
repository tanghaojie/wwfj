<template>
  <view class="main-view j-flex j-flex-column">
    <uni-search-bar
      placeholder="搜索"
      @confirm="search"
      cancelButton="auto"
      bgColor=""
      class="j-flex-nogrow-noshrink search-bar"
    ></uni-search-bar>

    <view class="regionFilter">
      <simple-address
        ref="addressPicker"
        themeColor="#007AFF"
        :pickerValueDefault="region.index"
        @onConfirm="onAddresPickerConfirm"
        type="bottom"
      ></simple-address>
      <!-- 按行政区筛选 -->
      <view class="j-flex j-flex-row">
        <view class="title">
          <text class="title-text">按行政区筛选</text>
        </view>
        <view class="region input-inline-wrapper" @click="openAddresPicker">
          {{ region.label }}
        </view>
        <view
          class="clear j-flex j-flex-center"
          @click="regionClear"
          v-show="region.label"
        >
          <icon type="clear" />
        </view>
      </view>
    </view>

    <view
      class="j-flex j-flex-row j-flex-nowrap j-flex-nogrow-noshrink tabbar "
    >
      <view
        v-for="(tab, index) in tabBars"
        :key="tab.id"
        class="j-flex-nowrap tabbar-item"
        @click="tabBarTap"
        :data-current="index"
      >
        <text
          class="j-flex-nowrap tabbar-item-title"
          :class="tabIndex == index ? 'tabbar-item-title-active' : ''"
          >{{ tab.name }}</text
        >
      </view>
    </view>

    <view class="j-w-100 list">
      <view
        v-if="tabIndex === 0 && pendingViewDatas && pendingViewDatas.length > 0"
      >
        <item
          :key="vdata.id"
          v-for="vdata in pendingViewDatas"
          :title="vdata.title"
          :content="vdata.content"
          :bottom="vdata.bottom"
          @click.native="itemTaped({ id: vdata.id, state: vdata.data.state })"
        ></item>
        <view v-if="pendingHasMore" class="tap-more" @click="moreTaped"
          >点击加载更多</view
        >
      </view>
      <view
        v-else-if="
          tabIndex === 1 && finishedViewDatas && finishedViewDatas.length > 0
        "
      >
        <item
          :key="vdata.id"
          v-for="vdata in finishedViewDatas"
          :title="vdata.title"
          :content="vdata.content"
          :bottom="vdata.bottom"
          @click.native="itemTaped({ id: vdata.id, state: vdata.data.state })"
        ></item>
        <view v-if="finishedHasMore" class="tap-more" @click="moreTaped"
          >点击加载更多</view
        >
      </view>
      <view class="nothing" v-else></view>
    </view>

    <view class="fixed-tool-bar fixed-tool-bar-wx">
      <arrow-button
        unit="rpx"
        :wh="100"
        :symbolwidth="8"
        bg="gray"
        symbolcolor="#fff"
        class="top-button"
        @click.native="toTopTaped"
        v-if="scrollTop > 1000"
      ></arrow-button>

      <div style="height: 40rpx"></div>

      <plus-button
        unit="rpx"
        :wh="100"
        bg="#007aff"
        symbolcolor="#fff"
        class="plus-button"
        @click.native="plusTaped"
      ></plus-button>
    </view>
  </view>
</template>

<script>
import uniFab from '@/components/uni-fab/uni-fab.vue'
import plusButton from '@/components/buttons/plus.vue'
import arrowButton from '@/components/buttons/arrow.vue'
import test from '@/components/buttons/test.vue'
import uniSearchBar from '@/components/uni-search-bar/uni-search-bar.vue'
import simpleAddress from '@/components/simple-address/simple-address.nvue'
import item from './item.vue'
import { USER_INFO } from '@/store/storage-keys.js'

export default {
  mounted() {
    this.tabIndex = 0
    this.getPendingData()
    this.getFinishedData()
  },
  data() {
    return {
      pendingViewDatas: [],
      pendingTotal: 0,
      pendingHasMore: false,
      finishedViewDatas: [],
      finishedTotal: 0,
      finishedHasMore: false,
      scrollTop: 0,
      tabBars: [
        {
          name: '待处理',
          id: 'daichuli'
        },
        {
          name: '已结办',
          id: 'yichuli'
        }
      ],
      tabIndex: null,
      region: {
        label: '',
        index: [22, 0, 0],
        code: ''
      }
    }
  },
  components: {
    uniFab,
    plusButton,
    arrowButton,
    test,
    uniSearchBar,
    item,
    simpleAddress
  },
  onLoad() {},
  methods: {
    plusTaped() {
      uni.navigateTo({
        url: 'detailv2'
      })
    },
    toTopTaped() {
      uni.pageScrollTo({
        scrollTop: 0,
        duration: 300
      })
    },
    search(res) {
      console.log('Search: ' + res.value)
    },
    tabBarTap(e) {
      let index = parseInt(
        e.target.dataset.current || e.currentTarget.dataset.current || 0
      )
      if (this.tabIndex === index) {
        return
      }
      this.tabIndex = index
    },
    getPendingData(refresh = true) {
      const token =
        this.$store.state.accessToken ||
        uni.getStorageSync(USER_INFO).accessToken
      console.log(token)
      uni.showLoading({
        title: '加载中'
      })
      if (refresh) {
        this.pendingViewDatas = []
        this.pendingTotal = 0
      } else {
        if (!this.pendingHasMore) {
          uni.hideLoading()
          uni.showToast({
            title: '没有更多了',
            duration: 1000
          })
          return
        }
      }
      uni
        .request({
          url: this.BaseUrl + '/api/services/app/FJ/GetPendingList',
          data: {
            skipCount: this.pendingTotal,
            maxResultCount: 2
          },
          header: {
            Authorization: 'Bearer ' + token
          }
        })
        .then(data => {
          var [error, res] = data
          let errorText = null
          uni.hideLoading()
          uni.stopPullDownRefresh()
          if (error || !res.data.success) {
            console.log(res)
            console.log(error)
            let text = '获取数据失败，请重试'
            if (res && res.data && res.data.error && res.data.error.message) {
              text = res.data.error.message
            }
            uni.showToast({
              title: text,
              duration: 1500
            })
            return
          }
          const pendingData = []
          let result = res.data
          let total = result.result.totalCount || 0
          let items = result.result.items || []
          let len = items.length
          if (refresh) {
            this.pendingTotal = len
          } else {
            this.pendingTotal += len
          }
          this.pendingHasMore = this.pendingTotal < total ? true : false
          for (let index = 0; index < len; index++) {
            let item = items[index]
            pendingData.push({
              data: item,
              id: item.id,
              title: {
                left: item.name,
                right: item.stateName
              },
              content: [
                '项目性质：' + item.projPropertyName,
                '用地性质：' + item.landPropertyName,
                '详细地址：' + item.regionName + ' ' + item.locationDetail
              ],
              bottom: {
                left: item.creationTimeStr
              }
            })
          }
          this.pendingViewDatas = this.pendingViewDatas.concat(pendingData)
        })
    },
    getFinishedData(refresh = true) {
      const token =
        this.$store.state.accessToken ||
        uni.getStorageSync(USER_INFO).accessToken
      uni.showLoading({
        title: '加载中'
      })
      if (refresh) {
        this.finishedViewDatas = []
        this.finishedTotal = 0
      } else {
        if (!this.finishedHasMore) {
          uni.hideLoading()
          uni.showToast({
            title: '没有更多了',
            duration: 1000
          })
          return
        }
      }
      uni
        .request({
          url: this.BaseUrl + '/api/services/app/FJ/GetFinishedList', //仅为示例，并非真实接口地址。
          data: {
            skipCount: this.finishedTotal,
            maxResultCount: 20
          },
          header: {
            Authorization: 'Bearer ' + token
          }
        })
        .then(data => {
          var [error, res] = data
          let errorText = null
          uni.hideLoading()
          uni.stopPullDownRefresh()
          if (error || !res.data.success) {
            console.log(res)
            console.log(error)
            let text = '获取数据失败，请重试'
            if (res && res.data && res.data.error && res.data.error.message) {
              text = res.data.error.message
            }
            uni.showToast({
              title: text,
              duration: 1500
            })
            return
          }
          const finishedData = []
          let result = res.data
          let total = result.result.totalCount || 0
          let items = result.result.items || []
          let len = items.length
          if (refresh) {
            this.finishedTotal = len
          } else {
            this.finishedTotal += len
          }
          this.finishedHasMore = this.finishedTotal < total ? true : false

          for (let index = 0; index < items.length; index++) {
            let item = items[index]
            finishedData.push({
              data: item,
              id: item.id,
              title: {
                left: item.name,
                right: item.stateName
              },
              content: [
                '项目性质：' + item.projPropertyName,
                '用地性质：' + item.landPropertyName,
                '详细地址：' + item.regionName + ' ' + item.locationDetail
              ],
              bottom: {
                left: item.creationTimeStr
              }
            })
          }
          this.finishedViewDatas = this.finishedViewDatas.concat(finishedData)
        })
    },
    refreshViewData(refresh = true) {
      let tabId = this.tabBars[this.tabIndex].id
      if (tabId === 'daichuli') {
        this.getPendingData(refresh)
      } else if (tabId === 'yichuli') {
        this.getFinishedData(refresh)
      } else {
        throw 'new branch is added'
      }
    },
    moreTaped() {
      this.refreshViewData(false)
    },
    itemTaped(opt) {
      uni.navigateTo({
        url: 'detailv2?id=' + opt.id + '&state=' + opt.state
      })
    },
    startPullDownRefresh() {
      this.refreshViewData()
    },
    onAddresPickerConfirm(e) {
      this.region.label = e.label
      this.region.index = e.value
      this.region.code = e.areaCode
    },
    openAddresPicker() {
      this.$refs.addressPicker.open()
    },
    regionClear() {
      this.region.label = ''
      this.region.index = [22, 0, 0]
      this.region.code = ''
    }
  },
  onPullDownRefresh() {
    this.refreshViewData()
  },
  onReachBottom() {
    this.refreshViewData(false)
  },
  onPageScroll(res) {
    this.scrollTop = res.scrollTop
  },
  watch: {
    tabIndex: function(newIndex, oldIndex) {
      // uni.startPullDownRefresh()
    }
  }
}
</script>

<style lang="scss" scoped>
.list {
  flex-grow: 1;
  padding-bottom: 1rpx;
  .test {
    height: 300rpx;
  }
  .test-blue {
    background-color: blue;
  }
  .test-green {
    background-color: green;
  }

  .tap-more {
    height: 60rpx;
    font-size: 28rpx;
    line-height: 60rpx;
    padding: 12rpx;
    background-color: rgb(180, 180, 180);
    color: white;
    text-align: center;
  }

  .nothing {
    display: flex;
  }
  .nothing::before {
    background-color: #eee;
    display: flex;
    content: '暂无消息';
    justify-content: center;
    align-items: center;
    width: 100%;
    color: #888;
    font-size: 38rpx;
    height: 100%;
  }
}

.tabbar {
  width: 100%;
  height: 80rpx;
  flex-shrink: 0;
  padding: 1px 0;
  justify-content: space-around;
  align-items: center;
  border-color: #cccccc;
  border-bottom-style: solid;
  border-bottom-width: 1px;

  .tabbar-item {
    padding-left: 34rpx;
    padding-right: 34rpx;

    .tabbar-item-title {
      color: #555;
      font-size: 28rpx;
      height: 80rpx;
      line-height: 80rpx;
    }

    .tabbar-item-title-active {
      color: #007aff;
      position: relative;

      &::after {
        content: '';
        position: absolute;
        bottom: -10rpx;
        left: 20rpx;
        right: 20rpx;
        height: 4rpx;
        background-color: #007aff;
      }
    }
  }
}

/* #ifdef MP-WEIXIN */
.fixed-tool-bar-wx {
  bottom: 100rpx !important;
}
/* #endif */

.fixed-tool-bar {
  position: fixed;
  right: 30rpx;
  bottom: 160rpx;
  padding: 10rpx;

  .plus-button {
  }

  .top-button {
  }
}

.regionFilter {
  padding: 20rpx 10rpx;
  border-color: #cccccc;
  border-bottom-style: solid;
  border-bottom-width: 2rpx;
  .title {
    padding: 0 16rpx;
    color: #999;
    font-size: 0.8rem;
    flex: 0 0 auto;
  }
  .region {
    color: #333;
    flex: 1 0 auto;
    text-align: center;
    font-size: 0.8rem;
  }
  .clear {
    padding: 0 16rpx;
    flex: 0 0 auto;
  }
}
</style>
