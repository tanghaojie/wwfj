<template>
  <view class="proj-company-select j-flex j-flex-column">
    <uni-search-bar
      placeholder="搜索"
      @confirm="searchConfirm"
      @cancel="searchCancel"
      @input="searchInput"
      cancelButton="auto"
      bgColor=""
      class="j-flex-nogrow-noshrink search-bar"
    ></uni-search-bar>
    <view class="list">
      <view
        v-for="(item, index) in companies"
        :key="index"
        class="item-wrapper"
        @click="select(item)"
      >
        <view class="item">
          <view class="name">{{ item.name }}</view>
          <view class="location">{{ item.registeredLocation }}</view>
          <view class="bottom j-flex j-flex-row">
            <view class="phone">{{ item.contactInfo }}</view>
            <view class="contact">{{ item.responsiblePerson }}</view>
          </view>
        </view>
      </view>
    </view>
    <view v-show="hasMore" class="tap-more" @click="moreTaped"
      >点击加载更多</view
    >
  </view>
</template>

<script>
import uniSearchBar from '@/components/uni-search-bar/uni-search-bar.vue'
import { USER_INFO } from '@/store/storage-keys.js'

export default {
  name: '',
  data() {
    return {
      emitName: null,
      search: null,
      companies: [],
      total: 0
    }
  },
  components: { uniSearchBar },
  computed: {
    hasMore() {
      return this.total > this.companies.length
    }
  },
  watch: {},
  methods: {
    searchConfirm(res) {
      const value = res.value
      if (value) {
        this.requestData(true, value)
      }
    },
    searchCancel() {
      this.requestData(true)
    },
    searchInput(res) {
      const value = res.value
      if (value) {
        this.requestData(true, value)
      }
    },
    moreTaped() {
      this.requestData(false)
    },
    requestData(refresh = true, nameFilter = null) {
      if (refresh) {
        this.companies = []
      } else {
        if (!this.hasMore) {
          return
        }
      }
      uni.showLoading({ title: '加载中' })
      const token =
        this.$store.state.accessToken ||
        uni.getStorageSync(USER_INFO).accessToken

      uni
        .request({
          url: this.BaseUrl + '/api/services/app/Company/GetAll',
          data: {
            skipCount: this.companies.length,
            maxResultCount: 10,
            nameFilter: nameFilter
          },
          header: { Authorization: 'Bearer ' + token }
        })
        .then(data => {
          var [error, res] = data
          uni.hideLoading()
          uni.stopPullDownRefresh()
          if (error || !res.data.success) {
            uni.showToast({
              title: '获取数据失败，请重试',
              duration: 1500
            })
            return
          }
          const result = res.data
          this.total = result.result.totalCount || 0
          const items = result.result.items || []

          this.companies = this.companies.concat(items)
        })
    },
    select(company) {
      uni.$emit(this.emitName, company)
      uni.navigateBack()
    }
  },
  mounted() {
    this.requestData()
  },
  onLoad(option) {
    this.emitName = option.emitName
  },
  onPullDownRefresh() {
    this.requestData(true)
  },
  onReachBottom() {
    this.requestData(false)
  }
}
</script>

<style lang="scss" scope>
.proj-company-select {
  //   .search-bar {
  //   }
  .list {
    // background-color: green;
    .item-wrapper {
      border-bottom: 1px solid #ccc;
      padding: 12px 16px;
      .item {
        &::after {
          content: '';
        }
        .name {
          padding: 5px 0;
          font-size: 0.9rem;
        }
        .location {
          font-size: 0.7rem;
          color: #858585;
        }
        .bottom {
          justify-content: space-between;
          font-size: 0.8rem;
          color: #333;
          //   .contact {
          //   }
          //   .phone {
          //   }
        }
      }
    }
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
}
</style>
