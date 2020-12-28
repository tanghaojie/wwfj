<template>
  <view class="excavate">
    <!-- 工程项目名称 -->
    <view class="input-group">
      <view class="title">
        <text class="title-text title-text-require ">工程项目名称</text>
      </view>
      <view class="input-wrapper">
        <input
          class="input"
          @input="onExcavationProjNameInput"
          placeholder="请输入工程项目名称"
          :value="excavationProjName"
        />
      </view>
    </view>

    <!-- 是否具备考古发掘入场条件 -->
    <view class="input-group">
      <view class="title">
        <text class="title-text">是否具备考古发掘入场条件</text>
      </view>
      <view class="input-wrapper">
        <radio-group
          @change="onIfHaveTheConditionsForExcavationTypeChange"
          class="j-flex j-flex-row j-w-100"
          style="justify-content: space-around; align-items: center"
        >
          <label
            class="j-flex j-flex-row j-flex-center"
            v-for="(item, index) in ifHaveTheConditionsForExcavationTypes"
            :key="item.value"
          >
            <view>
              <radio
                :value="item.value"
                :checked="
                  index === ifHaveTheConditionsForExcavationTypesCurrent
                "
              />
            </view>
            <view>{{ item.value }}</view>
          </label>
        </radio-group>
      </view>
    </view>

    <view v-show="ifHaveTheConditionsForExcavationTypesCurrent === 2">
      <!-- 不具备考古发掘入场条件原因 -->
      <view class="input-group">
        <view class="title"
          ><text class="title-text">不具备考古发掘入场条件原因</text></view
        >
        <view class="input-wrapper">
          <checkbox-group
            @change="onNotHaveTheConditionsForExcavationReasonsChange"
            class="j-w-100"
            style="font-size: 0.8rem"
          >
            <label
              v-for="item in notHaveTheConditionsForExcavationReasonItems"
              :key="item.value"
              class="j-flex j-flex-row j-w-100 p-ud-5"
            >
              <view>
                <checkbox :value="item.value" :checked="item.checked" />
              </view>
              <view style="margin-left: 10px;" v-if="item.value !== '其他'">{{
                item.value
              }}</view>
              <view
                style="margin-left: 10px; color: #888"
                v-else
                class="j-flex j-flex-row"
              >
                {{ item.value }}
                <input
                  class="input"
                  @input="onOtherNotHaveTheConditionsForExcavationReasonChange"
                  placeholder="请输入"
                  :value="otherNotHaveTheConditionsForExcavationReason"
                  style="font-size: 0.8rem; color: #000; margin-left: 10px"
                />
              </view>
            </label>
          </checkbox-group>
        </view>
      </view>
    </view>

    <view v-show="ifHaveTheConditionsForExcavationTypesCurrent !== 2">
      <view v-show="ifHaveTheConditionsForExcavationTypesCurrent === 1">
        <!-- 部分具备发掘入场条件面积 -->
        <view class="input-group">
          <view class="title">
            <text class="title-text">部分具备发掘入场条件面积</text>
          </view>
          <view class="input-wrapper">
            <input
              class="input"
              @input="onPartHaveTheConditionsForExcavationAreaInput"
              placeholder="请输入..."
              :value="partHaveTheConditionsForExcavationArea"
            />
          </view>
        </view>
      </view>

      <view v-show="ifHaveTheConditionsForExcavationTypesCurrent === 0"></view>

      <!-- 是否启动考古发掘 -->
      <view class="input-group">
        <view class="title">
          <text class="title-text">是否启动考古发掘</text>
        </view>
        <view class="input-wrapper">
          <radio-group
            @change="onIfStartExcavationTypeChange"
            class="j-flex j-flex-row j-w-100"
            style="justify-content: space-around; align-items: center"
          >
            <label
              class="j-flex j-flex-row j-flex-center"
              v-for="(item, index) in ifStartExcavationTypes"
              :key="item.value"
            >
              <view>
                <radio
                  :value="item.value"
                  :checked="index === ifStartExcavationTypesCurrent"
                />
              </view>
              <view>{{ item.value }}</view>
            </label>
          </radio-group>
        </view>
      </view>

      <view v-show="ifStartExcavationTypesCurrent !== 2">
        <!-- 入场时间 -->
        <view class="input-group j-flex j-flex-row ">
          <view class="title">
            <text class="title-text">入场时间</text>
          </view>
          <view class="input-inline-wrapper">
            <picker
              mode="date"
              :value="excavationEnterDate"
              @change="onExcavationEnterDateChange"
              class="text-center"
            >
              <view class="text-center">{{ excavationEnterDate }}</view>
            </picker>
          </view>
        </view>

        <!-- 部分发掘结束时间 -->
        <view class="input-group j-flex j-flex-row ">
          <view class="title">
            <text class="title-text">部分发掘结束时间</text>
          </view>
          <view class="input-inline-wrapper">
            <picker
              mode="date"
              :value="partExcavationEndDate"
              @change="onPartExcavationEndDateChange"
              class="text-center"
            >
              <view class="text-center">{{ partExcavationEndDate }}</view>
            </picker>
          </view>
        </view>

        <!-- 全部发掘结束时间 -->
        <view class="input-group j-flex j-flex-row ">
          <view class="title">
            <text class="title-text">全部发掘结束时间</text>
          </view>
          <view class="input-inline-wrapper">
            <picker
              mode="date"
              :value="excavationEndDate"
              @change="onExcavationEndDateChange"
              class="text-center"
            >
              <view class="text-center">{{ excavationEndDate }}</view>
            </picker>
          </view>
        </view>

        <!-- 考古发掘协议签订时间 -->
        <view class="input-group j-flex j-flex-row ">
          <view class="title">
            <text class="title-text">考古发掘协议签订时间</text>
          </view>
          <view class="input-inline-wrapper">
            <picker
              mode="date"
              :value="signExcavationAgreementDate"
              @change="onSignExcavationAgreementDateChange"
              class="text-center"
            >
              <view class="text-center">{{ signExcavationAgreementDate }}</view>
            </picker>
          </view>
        </view>
      </view>
    </view>
  </view>
</template>

<script>
export default {
  components: {},
  props: {},
  data() {
    return {
      excavationProjName: '',

      ifHaveTheConditionsForExcavationTypes: [
        {
          value: '完全具备'
        },
        {
          value: '部分具备'
        },
        {
          value: '不具备'
        }
      ],
      ifHaveTheConditionsForExcavationTypesCurrent: 0,

      notHaveTheConditionsForExcavationReasonItems: [
        // {
        //   value: '项目未打围'
        // },
        // {
        //   value: '未清理地表建渣及堆土'
        // },
        // {
        //   value: '地表下硬化基础'
        // },
        // {
        //   value: '青苗赔偿未解决'
        // },
        // {
        //   value: '地下官网未清理'
        // },
        // {
        //   value: '水电未供应'
        // },
        // {
        //   value: '临时建筑设施未提供'
        // },
        {
          value: '其他'
        }
      ],
      otherNotHaveTheConditionsForExcavationReason: '',

      partHaveTheConditionsForExcavationArea: '',

      ifStartExcavationTypes: [
        {
          value: '全部启动'
        },
        {
          value: '部分启动'
        },
        {
          value: '不启动'
        }
      ],
      ifStartExcavationTypesCurrent: 0,

      excavationEnterDate: '',

      partExcavationEndDate: '',

      excavationEndDate: '',

      signExcavationAgreementDate: ''
    }
  },
  computed: {},
  watch: {},
  created() {},
  mounted() {},
  methods: {
    onExcavationProjNameInput(e) {
      this.excavationProjName = e.detail.value
    },

    onIfHaveTheConditionsForExcavationTypeChange(e) {
      for (
        let i = 0;
        i < this.ifHaveTheConditionsForExcavationTypes.length;
        i++
      ) {
        if (
          this.ifHaveTheConditionsForExcavationTypes[i].value === e.target.value
        ) {
          this.ifHaveTheConditionsForExcavationTypesCurrent = i
          break
        }
      }
    },

    onNotHaveTheConditionsForExcavationReasonsChange(e) {
      var items = this.notHaveTheConditionsForExcavationReasonItems,
        values = e.detail.value
      for (var i = 0, lenI = items.length; i < lenI; ++i) {
        const item = items[i]
        if (values.includes(item.value)) {
          this.$set(item, 'checked', true)
        } else {
          this.$set(item, 'checked', false)
        }
      }
    },

    onOtherNotHaveTheConditionsForExcavationReasonChange(e) {
      this.otherNotHaveTheConditionsForExcavationReason = e.detail.value
      var items = this.notHaveTheConditionsForExcavationReasonItems
      for (var i = 0, lenI = items.length; i < lenI; ++i) {
        const item = items[i]
        if (item.value === '其他') {
          this.$set(
            item,
            'reason',
            this.otherNotHaveTheConditionsForExcavationReason
          )
        }
      }
    },

    onPartHaveTheConditionsForExcavationAreaInput(e) {
      this.partHaveTheConditionsForExcavationArea = e.detail.value
    },

    onIfStartExcavationTypeChange(e) {
      for (let i = 0; i < this.ifStartExcavationTypes.length; i++) {
        if (this.ifStartExcavationTypes[i].value === e.target.value) {
          this.ifStartExcavationTypesCurrent = i
          break
        }
      }
    },

    onExcavationEnterDateChange(e) {
      this.excavationEnterDate = e.detail.value
    },

    onPartExcavationEndDateChange(e) {
      this.partExcavationEndDate = e.detail.value
    },

    onExcavationEndDateChange(e) {
      this.excavationEndDate = e.detail.value
    },

    onSignExcavationAgreementDateChange(e) {
      this.signExcavationAgreementDate = e.detail.value
    },

    getVM() {
      const obj = {
        excavationProjName: this.excavationProjName,
        ifHaveTheConditionsForExcavation: this
          .ifHaveTheConditionsForExcavationTypes[
          this.ifHaveTheConditionsForExcavationTypesCurrent
        ].value,

        notHaveTheConditionsForExcavationReasons: [],
        partHaveTheConditionsForExcavationArea: this
          .partHaveTheConditionsForExcavationArea,
        ifStartExcavation: this.ifStartExcavationTypes[
          this.ifStartExcavationTypesCurrent
        ].value,
        excavationEnterDate: this.excavationEnterDate,
        partExcavationEndDate: this.partExcavationEndDate,
        excavationEndDate: this.excavationEndDate,
        signExcavationAgreementDate: this.signExcavationAgreementDate
      }
      const notHaveTheConditionsForExcavationReasons = []
      this.notHaveTheConditionsForExcavationReasonItems.forEach(q => {
        if (q.checked) {
          const value = q.value
          if (value === '其他') {
            notHaveTheConditionsForExcavationReasons.push(q.reason)
          } else {
            notHaveTheConditionsForExcavationReasons.push(q.value)
          }
        }
      })
      obj.notHaveTheConditionsForExcavationReasons = notHaveTheConditionsForExcavationReasons

      return obj
    },

    setVM(obj) {
      this.excavationProjName = obj.excavationProjName

      const haveTheConditionForExcavation = obj.ifHaveTheConditionsForExcavation
      this.ifHaveTheConditionsForExcavationTypes.every((item, index) => {
        if (item.value === haveTheConditionForExcavation) {
          this.ifHaveTheConditionsForExcavationTypesCurrent = index
          return false
        }
        return true
      })

      const notHaveTheConditionsForExcavationReasons =
        obj.notHaveTheConditionsForExcavationReasons
      notHaveTheConditionsForExcavationReasons.forEach(x => {
        let find = false
        this.notHaveTheConditionsForExcavationReasonItems.every(y => {
          if (x === y.value) {
            this.$set(y, 'checked', true)
            find = true
            return false
          }
          return true
        })
        if (!find) {
          this.notHaveTheConditionsForExcavationReasonItems.every(y => {
            if (y.value === '其他') {
              this.$set(y, 'checked', true)
              find = true
              this.$set(y, 'reason', x)
              this.otherNotHaveTheConditionsForExcavationReason = x
              return false
            }
            return true
          })
        }
      })

      this.partHaveTheConditionsForExcavationArea =
        obj.partHaveTheConditionsForExcavationArea

      const ifStartExcavation = obj.ifStartExcavation
      this.ifStartExcavationTypes.every((item, index) => {
        if (item.value === ifStartExcavation) {
          this.ifStartExcavationTypesCurrent = index
          return false
        }
        return true
      })
      this.excavationEnterDate = this.getYMD(obj.excavationEnterDate)
      this.partExcavationEndDate = this.getYMD(obj.partExcavationEndDate)
      this.excavationEndDate = this.getYMD(obj.excavationEndDate)
      this.signExcavationAgreementDate = this.getYMD(
        obj.signExcavationAgreementDate
      )
    }
  }
}
</script>

<style lang="scss" scoped></style>
