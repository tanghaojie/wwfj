<template>
  <view class="new">
    <view class="top-space"></view>

    <view class="content">
      <view
        class="input-group"
        :class="c.titleFormSingleRow ? ' j-flex j-flex-row ' : ''"
        v-for="(c, index) in components"
        :key="c.id"
      >
        <view class="title">
          <text
            class="title-text"
            :class="c.required ? ' title-text-require ' : ''"
            >{{ c.title || '' }}</text
          >
        </view>
        <view
          :class="
            c.titleFormSingleRow ? 'input-inline-wrapper' : 'input-wrapper'
          "
        >
          <input
            v-if="c.type === null || c.type === '' || c.type === 'input'"
            class="input"
            :placeholder="c.input.placeholder || ''"
            :value="c.input.value"
            @input="onInput"
            :data-index="index"
          />

          <view v-else-if="c.type === 'address-picker'" class="j-w-100">
            <view @click="openAddresPicker(index)" class="text-center">
              {{ c.addressPicker.label || '' }}
            </view>
            <simple-address
              :ref="'addressPicker' + index"
              themeColor="#007AFF"
              :pickerValueDefault="c.addressPicker.indexes"
              @onConfirm="onAddresPickerConfirm"
              :jtIndex="index"
            ></simple-address
          ></view>
        </view>
      </view>

      <!--


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
      -->
    </view>

    <button class="share-button .j-theme-bg" @click="onCommit">提交</button>
  </view>
</template>

<script>
import simpleAddress from '@/components/simple-address/simple-address.nvue'

export default {
  name: '',
  data() {
    return {
      components: [
        {
          id: 0,
          type: 'input',
          title: '项目名称',
          required: true,
          titleFormSingleRow: false,
          input: {
            value: null,
            placeholder: '请输入项目名称'
          }
        },
        {
          id: 1,
          type: 'address-picker',
          title: '所在区域',
          required: true,
          titleFormSingleRow: true,
          addressPicker: {
            label: '',
            indexes: [22, 0, 0]
          }
        },
        {
          id: 3,
          type: 'input',
          title: '详细位置',
          required: true,
          titleFormSingleRow: false,
          input: {
            value: null,
            placeholder: '请输入详细位置'
          }
        }
      ]
    }
  },
  components: {
    simpleAddress
  },
  computed: {},
  watch: {},
  methods: {
    onInput(e) {
      let index = e.target.dataset.index || e.currentTarget.dataset.index
      this.components[index].input.value = e.target.value
    },
    onAddresPickerConfirm(e) {
      this.components[e.jtIndex].addressPicker.label = e.label
      this.components[e.jtIndex].addressPicker.indexes = e.value
    },
    onCommit() {
      console.log(this.components)
    },
    onProjNameInput(e) {
      this.projName = e.detail.value
    },
    onLocDetailInput(e) {
      this.locDetail = e.detail.value
    },
    onLandPropChange: function(e) {
      this.landPropIndex = e.detail.value
    },
    onProjPropChange: function(e) {
      this.projPropIndex = e.detail.value
    },
    openAddresPicker(index) {
      this.$refs['addressPicker' + index][0].open()
    }
  },
  mounted() {
    for (let index = 0; index < this.components.length; index++) {
      const c = this.components[index]
      if (c.type === 'address-picker') {
        if (c.addressPicker.indexes && c.addressPicker.indexes.length === 3) {
          const picker = this.$refs['addressPicker' + index][0]
          this.components[index].addressPicker.label =
            picker.provinceDataList[c.addressPicker.indexes[0]].label +
            '-' +
            picker.cityDataList[c.addressPicker.indexes[1]].label +
            '-' +
            picker.areaDataList[c.addressPicker.indexes[2]].label
        }
      }
    }
  }
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
        padding-right: 20rpx;
        .title-text {
          font-size: 34rpx;
          color: #222;
        }
        .title-text-require::after {
          content: ' *';
          color: red;
        }
      }
      .input-inline-wrapper {
        flex-grow: 1;
        display: flex;
        flex-direction: row;
        flex-wrap: nowrap;
      }
      .text-center {
        height: 48rpx;
        font-size: 34rpx;
        flex: 1;
        width: 100%;
        text-align: center;
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
