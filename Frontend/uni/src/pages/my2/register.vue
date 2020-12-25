<template>
  <div class="register">
    <simple-address
      ref="addressPicker"
      themeColor="#007AFF"
      :pickerValueDefault="departmentRegion.index"
      @onConfirm="onAddresPickerConfirm"
    ></simple-address>

    <!-- 用户名 -->
    <view class="input-group j-flex j-flex-row">
      <view class="title j-flex j-flex-row j-flex-center">
        <text class="title-text title-text-require ">用户名</text>
      </view>
      <view class="input-inline-wrapper">
        <input
          class="input"
          @input="onUsernameInput"
          placeholder="请输入用户名"
          :value="username"
        />
      </view>
    </view>

    <!-- 密码 -->
    <view class="input-group j-flex j-flex-row ">
      <view class="title j-flex j-flex-row j-flex-center">
        <text class="title-text title-text-require ">密码</text>
      </view>
      <view class="input-inline-wrapper">
        <input
          class="input"
          @input="onPasswordInput"
          placeholder="输入密码"
          :value="password"
          type="password"
        />
      </view>
    </view>

    <!-- 确认密码 -->
    <view class="input-group j-flex j-flex-row ">
      <view class="title j-flex j-flex-row j-flex-center">
        <text class="title-text title-text-require ">再次输入密码</text>
      </view>
      <view class="input-inline-wrapper">
        <input
          class="input"
          @input="onPassword2Input"
          placeholder="再次输入密码以确认"
          :value="password2"
          type="password"
        />
      </view>
    </view>

    <!-- 所属部门 -->
    <view class="input-group j-flex j-flex-row ">
      <view class="title  j-flex j-flex-row j-flex-center">
        <text class="title-text title-text-require ">所属部门</text>
      </view>
      <view class="input-inline-wrapper">
        <picker
          mode="selector"
          :value="departmentIndex"
          :range="departmentProps"
          range-key="name"
          class="text-center"
          @change="onDepartmentChange"
        >
          <view class="">{{ departmentProps[departmentIndex].name }}</view>
        </picker>
      </view>
    </view>

    <!-- 管辖区域 -->
    <view
      v-if="departmentRegionVisible"
      class="input-group j-flex j-flex-row ani"
    >
      <view class="title j-flex j-flex-row j-flex-center">
        <text class="title-text title-text-require "> 管辖区域</text>
      </view>
      <view class="input-inline-wrapper">
        <view @click="openAddresPicker" class="text-center">
          {{ departmentRegion.label }}
        </view>
      </view>
    </view>

    <!-- 真实姓名 -->
    <view class="input-group j-flex j-flex-row ">
      <view class="title j-flex j-flex-row j-flex-center">
        <text class="title-text ">真实姓名</text>
      </view>
      <view class="input-inline-wrapper">
        <input
          class="input"
          @input="onRealnameInput"
          placeholder="输入您的真实姓名"
          :value="realname"
        />
      </view>
    </view>

    <!-- 电话 -->
    <view class="input-group j-flex j-flex-row ">
      <view class="title j-flex j-flex-row j-flex-center">
        <text class="title-text ">电话</text>
      </view>
      <view class="input-inline-wrapper">
        <input
          class="input"
          @input="onPhoneInput"
          placeholder="输入您的电话"
          :value="phone"
          type="number"
        />
      </view>
    </view>

    <button class="share-button j-theme-bg m-b-100" @click="onCommit">
      注册
    </button>
  </div>
</template>

<script>
import simpleAddress from '@/components/simple-address/simple-address.vue'

export default {
  components: {},
  props: {},
  data() {
    return {
      departmentRegion: {
        label: '',
        index: [22, 0, 0],
        code: ''
      },
      username: '',
      password: '',
      password2: '',
      departmentIndex: 0,
      phone: '',
      realname: ''
    }
  },
  computed: {
    departmentRegionVisible() {
      return this.departmentIndex === this.Department.KanTanYeWu
    },
    departmentProps() {
      let r = new Array(this.Department.length)
      for (let key in this.Department) {
        let chn = ''
        switch (key) {
          case 'KanTanYeWu':
            chn = '勘探业务部门'
            break
          case 'KanTanBan':
            chn = '勘探办'
            break
          case 'FaJueXianChangeFuZeRen':
            chn = '发掘现场负责人'
            break
          case 'WenBaoChu':
            chn = '文保处'
            break
          case 'Other':
            chn = '其他查看部门'
            break
          default:
            break
        }
        r[this.Department[key]] = {
          name: chn,
          key: key
        }
      }
      return r
    }
  },
  watch: {},
  created() {},
  mounted() {},
  methods: {
    onAddresPickerConfirm(e) {
      this.departmentRegion.label = e.label
      this.departmentRegion.index = e.value
      this.departmentRegion.code = e.areaCode
    },
    onUsernameInput(e) {
      this.username = e.detail.value
    },
    onPasswordInput(e) {
      this.password = e.detail.value
    },
    onPassword2Input(e) {
      this.password2 = e.detail.value
    },
    onDepartmentChange(e) {
      this.departmentIndex = e.detail.value
    },
    onPhoneInput(e) {
      this.phone = e.detail.value
    },
    onRealnameInput(e) {
      this.realname = e.detail.value
    },
    openAddresPicker() {
      this.$refs.addressPicker.open()
    },
    onCommit() {
      const {
        departmentRegion,
        username,
        password,
        password2,
        departmentIndex,
        phone,
        realname
      } = this
      if (
        !username ||
        !password ||
        !password2 ||
        departmentIndex == null ||
        departmentIndex < 0 ||
        (this.departmentRegionVisible &&
          (departmentRegion.label === null ||
            departmentRegion.label === undefined ||
            departmentRegion.label === '' ||
            departmentRegion.code === null ||
            departmentRegion.code === undefined ||
            departmentRegion.code === '' ||
            departmentRegion.index === null ||
            departmentRegion.index === undefined ||
            departmentRegion.index === ''))
      ) {
        uni.showToast({
          title: '请填写完整信息',
          duration: 1500
        })
        return
      }
      if (password !== password2) {
        uni.showToast({
          title: '输入密码不一致',
          duration: 1500
        })
      }
      uni.showLoading({ title: '' })
      uni
        .request({
          url: this.BaseUrl + '/api/services/app/User',
          method: 'POST',
          data: {
            username: username,
            password: password,
            department: departmentIndex,
            phone: phone,
            realname: realname,
            regionCode: departmentRegion.code,
            regionName: departmentRegion.label,
            regionIndex: departmentRegion.index.toString()
          },
          header: {
            'content-type': 'application/json'
          }
        })
        .then(data => {
          var [error, res] = data
          uni.hideLoading()
          if (error || !res.data.success || res.statusCode !== 200) {
            let text = '网络请求失败'
            if (res && res.data && res.data.error && res.data.error.message) {
              text = res.data.error.message
            }
            uni.showToast({
              title: text,
              duration: 1500
            })
            return
          }
          uni.navigateBack()
        })
    }
  }
}
</script>

<style lang="scss" scoped>
.register {
  padding: 10rpx 0;
  box-sizing: border-box;
  min-height: 100%;
  background-color: #f1f1f1;

  /deep/ .input-group {
    // margin: 30rpx 0;
    margin: 26rpx 0;
    background-color: #ffffff;
    padding: 10rpx 16rpx;

    .title {
      .title-text {
        font-size: 32rpx;
        line-height: 32rpx;
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
        line-height: 48rpx;
        font-size: 32rpx;
        flex: 1;
        width: 100%;
        text-align: center;
      }

      .input {
        margin-left: 32rpx;
        height: 48rpx;
        font-size: 32rpx;
        flex: 1;
      }
    }
    // .input-wrapper {
    //   margin-top: 15rpx;
    //   display: flex;
    //   flex-direction: row;
    //   flex-wrap: nowrap;

    //   .input {
    //     height: 48rpx;
    //     font-size: 32rpx;
    //     flex: 1;
    //   }
    // }
  }

  .share-button {
    margin-top: 30rpx;
    color: #fff;
  }

  .ani {
    animation: ww 1.5s;
    -webkit-animation: ww 1.5s;
    @keyframes ww {
      from {
        max-height: 0;
      }
      to {
        max-height: 200px;
      }
    }
  }
}
</style>
