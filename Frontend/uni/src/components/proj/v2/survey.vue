<template>
  <view class="survey">
    <!-- 与项目单位现场沟通时间 -->
    <view class="input-group j-flex j-flex-row ">
      <view class="title">
        <text class="title-text">与项目单位现场沟通时间</text>
      </view>
      <view class="input-inline-wrapper">
        <picker
          mode="date"
          :value="communicateWithProjCompanyDate"
          @change="onCommunicateWithProjCompanyDateChange"
          class="text-center"
        >
          <view class="text-center">{{ communicateWithProjCompanyDate }}</view>
        </picker>
      </view>
    </view>

    <!-- 是否具备考古勘探入场条件 -->
    <view class="input-group j-flex j-flex-row ">
      <view class="title j-flex j-flex-row j-flex-center ">
        <text class="title-text">是否具备考古勘探入场条件</text>
      </view>
      <view class="input-inline-wrapper j-flex j-flex-row j-flex-center ">
        <switch
          @change="ifHaveTheConditionsForSurveyChange"
          :checked="ifHaveTheConditionsForSurvey"
          style=""
        />
      </view>
    </view>

    <view v-show="!ifHaveTheConditionsForSurvey">
      <!-- 不具备入场条件原因 -->
      <view class="input-group">
        <view class="title"
          ><text class="title-text">不具备入场条件原因</text></view
        >
        <view class="input-wrapper">
          <checkbox-group
            @change="onNotHaveTheConditionsForSurveyReasonsChange"
            class="j-w-100"
            style="font-size: 0.8rem"
          >
            <label
              v-for="item in notHaveTheConditionsForSurveyReasonItems"
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
                  @input="onOtherNotHaveTheConditionsForSurveyReasonChange"
                  placeholder="请输入"
                  :value="otherNotHaveTheConditionsForSurveyReason"
                  style="font-size: 0.8rem; color: #000; margin-left: 10px"
                />
              </view>
            </label>
          </checkbox-group>
        </view>
      </view>
    </view>

    <view v-show="ifHaveTheConditionsForSurvey">
      <!-- 勘探正式入场时间 -->
      <view class="input-group j-flex j-flex-row ">
        <view class="title">
          <text class="title-text">勘探正式入场时间</text>
        </view>
        <view class="input-inline-wrapper">
          <picker
            mode="date"
            :value="surveyEnterDate"
            @change="onSurveyEnterDateChange"
            class="text-center"
          >
            <view class="text-center">{{ surveyEnterDate }}</view>
          </picker>
        </view>
      </view>

      <!-- 勘探结束时间 -->
      <view class="input-group j-flex j-flex-row ">
        <view class="title">
          <text class="title-text">勘探结束时间</text>
        </view>
        <view class="input-inline-wrapper">
          <picker
            mode="date"
            :value="surveyEndDate"
            @change="onSurveyEndDateChange"
            class="text-center"
          >
            <view class="text-center">{{ surveyEndDate }}</view>
          </picker>
        </view>
      </view>

      <!-- 是否转入考古发掘 -->
      <view class="input-group j-flex j-flex-row ">
        <view class="title j-flex j-flex-row j-flex-center ">
          <text class="title-text">是否转入考古发掘</text>
        </view>
        <view class="input-inline-wrapper j-flex j-flex-row j-flex-center ">
          <switch
            @change="ifExcavationChange"
            :checked="ifExcavation"
            style=""
          />
        </view>
      </view>

      <view v-show="!ifExcavation"> </view>
      <view v-show="ifExcavation">
        <!-- 遗存发现基本情况 -->
        <view class="input-group">
          <view
            v-if="addRemainInfoFormShown"
            class="add-remain-info j-flex j-flex-center"
          >
            <view class="content">
              <div class="title">遗存信息</div>
              <div
                class="close j-flex j-flex-row j-flex-center"
                @click="closeRemainInfo()"
              >
                <div class="wrapper">
                  <div class="x"></div>
                  <div class="x"></div>
                </div>
              </div>

              <picker-view
                indicator-style="height: 40px; border-top: 1px solid #e5e5e5; border-bottom: 1px solid #e5e5e5;"
                class="picker-view"
                @change="addRemainInfoChanged"
                :value="addRemainInfoIndexValue"
              >
                <picker-view-column>
                  <view
                    class="j-flex j-flex-center"
                    v-for="(item, index) in remainTypes"
                    :key="index"
                    >{{ item }}</view
                  >
                </picker-view-column>
                <picker-view-column>
                  <view
                    class="j-flex j-flex-center"
                    v-for="(item, index) in remainPeriods"
                    :key="index"
                    >{{ item }}</view
                  >
                </picker-view-column>
              </picker-view>

              <div class="op j-flex j-flex-row j-flex-center">
                <div class="cancel" @click="closeRemainInfo()">
                  取消
                </div>
                <div class="ok" @click="addRemainInfoOK">
                  确定
                </div>
              </div>
            </view>
          </view>

          <view class="title j-flex j-flex-row">
            <view class="j-flex j-flex-center" style="flex: 0 0 auto;"
              ><text class="title-text">遗存发现基本情况</text></view
            >
            <view
              style="flex: 1 1 auto;"
              class="j-flex j-flex-row j-flex-center"
              ><button
                size="mini"
                @click="addRemainInfoFormShown = true"
                class="title-text"
                style="color: #666"
              >
                点击添加
              </button></view
            >
          </view>
          <view class="input-wrapper" style="flex-wrap: wrap">
            <view
              class="remain-item j-flex j-flex-row j-flex-center"
              v-for="(item, index) in remainsInfo"
              :key="index"
            >
              <view class="info j-flex j-flex-column j-flex-center">
                <view class="type">{{ item[0] }}</view>
                <view class="period">{{ item[1] }}</view></view
              >
              <view
                class="delete j-flex j-flex-row j-flex-center"
                @click="remainItemDelete(index)"
              >
                <div class="wrapper">
                  <div class="x"></div>
                  <div class="x"></div>
                </div>
              </view>
            </view>
          </view>
        </view>

        <!-- 预计发掘面积 -->
        <view class="input-group j-flex j-flex-row ">
          <view class="title">
            <text class="title-text">预计发掘面积</text>
          </view>
          <view class="input-inline-wrapper">
            <picker
              mode="selector"
              :value="estimateExcavateAreaIndex"
              :range="estimateExcavateAreas"
              range-key="value"
              class="text-center"
              @change="onEstimateExcavateAreaChange"
            >
              <view class="">{{
                estimateExcavateAreas[estimateExcavateAreaIndex].value
              }}</view>
            </picker>
          </view>
        </view>

        <!-- 预计发掘面积（其他，手动输入） -->
        <view
          v-if="estimateExcavateAreaIndex === estimateExcavateAreas.length - 1"
          class="input-group j-flex j-flex-row "
        >
          <view class="title">
            <text class="title-text ">请输入</text>
          </view>
          <view class="input-inline-wrapper">
            <input
              class="input text-center"
              @input="onOtherEstimateExcavateAreaInput"
              placeholder="预计发掘面积"
              :value="otherEstimateExcavateArea"
              style="font-size: 0.9rem"
            />
          </view>
        </view>

        <!-- 预计发掘周期 -->
        <view class="input-group j-flex j-flex-row ">
          <view class="title">
            <text class="title-text">预计发掘周期</text>
          </view>
          <view class="input-inline-wrapper">
            <picker
              mode="selector"
              :value="estimateExcavateDurationIndex"
              :range="estimateExcavateDurations"
              range-key="value"
              class="text-center"
              @change="onEstimateExcavateDurationChange"
            >
              <view class="">{{
                estimateExcavateDurations[estimateExcavateDurationIndex].value
              }}</view>
            </picker>
          </view>
        </view>

        <!-- 预计发掘周期（其他，手动输入） -->
        <view
          v-if="
            estimateExcavateDurationIndex ===
              estimateExcavateDurations.length - 1
          "
          class="input-group j-flex j-flex-row "
        >
          <view class="title">
            <text class="title-text ">请输入</text>
          </view>
          <view class="input-inline-wrapper">
            <input
              class="input text-center"
              @input="onOtherEstimateExcavateDurationInput"
              placeholder="预计发掘周期"
              :value="otherEstimateExcavateDuration"
              style="font-size: 0.9rem"
            />
          </view>
        </view>
      </view>
    </view>
  </view>
</template>

<script>
import plusButton from '@/components/buttons/plus.vue'

export default {
  components: { plusButton },
  props: {},
  data() {
    return {
      communicateWithProjCompanyDate: '',

      ifHaveTheConditionsForSurvey: false,

      notHaveTheConditionsForSurveyReasonItems: [
        {
          value: '项目未打围'
        },
        {
          value: '项目现场地表存堆土'
        },
        {
          value: '建渣、地表硬化基础未清除'
        },
        {
          value: '青苗赔偿未解决'
        },
        {
          value: '地下存有官网等未清理'
        },
        {
          value: '其他'
        }
      ],
      otherNotHaveTheConditionsForSurveyReason: '',

      surveyEnterDate: '',

      surveyEndDate: '',

      ifExcavation: false,

      addRemainInfoFormShown: false,

      remainTypes: [
        '遗址',
        '墓葬',
        '窑址',
        '房址',
        '城墙',
        '建筑基址',
        '作坊',
        '其它'
      ],
      remainPeriods: [
        '新石器时代',
        '商周时期',
        '战国时期',
        '汉代',
        '南北朝',
        '唐宋',
        '明清',
        '其它'
      ],
      addRemainInfoIndexValue: [0, 0],
      addRemainInfoValue: ['遗址', '新石器时代'],

      remainsInfo: [],

      estimateExcavateAreaIndex: 0,
      estimateExcavateAreas: [
        { value: '0-200平方米' },
        { value: '200-400平方米' },
        { value: '400-600平方米' },
        { value: '600-800平方米' },
        { value: '800-1000平方米' },
        { value: '1000-1200平方米' },
        { value: '1200-1400平方米' },
        { value: '1400-1600平方米' },
        { value: '1600-1800平方米' },
        { value: '1800-2000平方米' },
        { value: '2000-2200平方米' },
        { value: '2200-2400平方米' },
        { value: '2400-2600平方米' },
        { value: '2600-2800平方米' },
        { value: '2800-3000平方米' },
        { value: '其他' }
      ],

      otherEstimateExcavateArea: '',

      estimateExcavateDurationIndex: 0,
      estimateExcavateDurations: [
        { value: '1个月' },
        { value: '2个月' },
        { value: '3个月' },
        { value: '4个月' },
        { value: '5个月' },
        { value: '6个月' },
        { value: '7个月' },
        { value: '8个月' },
        { value: '9个月' },
        { value: '10个月' },
        { value: '11个月' },
        { value: '12个月' },
        { value: '其他' }
      ],

      otherEstimateExcavateDuration: ''
    }
  },
  computed: {},
  watch: {},
  created() {},
  mounted() {},
  methods: {
    onCommunicateWithProjCompanyDateChange(e) {
      this.communicateWithProjCompanyDate = e.detail.value
    },
    ifHaveTheConditionsForSurveyChange(e) {
      this.ifHaveTheConditionsForSurvey = e.detail.value
    },

    onNotHaveTheConditionsForSurveyReasonsChange(e) {
      var items = this.notHaveTheConditionsForSurveyReasonItems,
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

    onOtherNotHaveTheConditionsForSurveyReasonChange(e) {
      this.otherNotHaveTheConditionsForSurveyReason = e.detail.value
      var items = this.notHaveTheConditionsForSurveyReasonItems
      for (var i = 0, lenI = items.length; i < lenI; ++i) {
        const item = items[i]
        if (item.value === '其他') {
          this.$set(
            item,
            'reason',
            this.otherNotHaveTheConditionsForSurveyReason
          )
        }
      }
    },

    onSurveyEnterDateChange(e) {
      this.surveyEnterDate = e.detail.value
    },

    onSurveyEndDateChange(e) {
      this.surveyEndDate = e.detail.value
    },

    ifExcavationChange(e) {
      this.ifExcavation = e.detail.value
    },

    closeRemainInfo() {
      this.addRemainInfoFormShown = false
      this.initRemainInfo()
    },

    addRemainInfoChanged(e) {
      const val = e.detail.value
      this.addRemainInfoValue[0] = this.remainTypes[val[0]]
      this.addRemainInfoValue[1] = this.remainPeriods[val[1]]
    },

    addRemainInfoOK() {
      this.remainsInfo.push(this.addRemainInfoValue.slice())
      this.closeRemainInfo()
    },

    initRemainInfo() {
      this.addRemainInfoValue = ['遗址', '新石器时代']
    },

    remainItemDelete(index) {
      this.remainsInfo.splice(index, 1)
    },

    onEstimateExcavateAreaChange(e) {
      this.estimateExcavateAreaIndex = e.detail.value
    },

    onOtherEstimateExcavateAreaInput(e) {
      this.otherEstimateExcavateArea = e.detail.value
    },

    onEstimateExcavateDurationChange(e) {
      this.estimateExcavateDurationIndex = e.detail.value
    },

    onOtherEstimateExcavateDurationInput(e) {
      this.otherEstimateExcavateDuration = e.detail.value
    },

    getVM() {
      const obj = {
        communicateWithProjCompanyDate: this.communicateWithProjCompanyDate,
        ifHaveTheConditionsForSurvey: this.ifHaveTheConditionsForSurvey,
        notHaveTheConditionsForSurveyReasons: [],
        surveyEnterDate: this.surveyEnterDate,
        surveyEndDate: this.surveyEndDate,
        ifExcavation: this.ifExcavation,
        remainsInfo: [],
        estimateExcavateArea: null,
        estimateExcavateDuration: null
      }
      const notHaveTheConditionsForSurveyReasons = []
      this.notHaveTheConditionsForSurveyReasonItems.forEach(q => {
        if (q.checked) {
          const value = q.value
          if (value === '其他') {
            notHaveTheConditionsForSurveyReasons.push(q.reason)
          } else {
            notHaveTheConditionsForSurveyReasons.push(q.value)
          }
        }
      })
      obj.notHaveTheConditionsForSurveyReasons = notHaveTheConditionsForSurveyReasons

      const remainsInfo = []
      this.remainsInfo.forEach(v => {
        remainsInfo.push(v[0] + '|' + v[1])
      })
      obj.remainsInfo = remainsInfo

      let estimateExcavateArea = this.estimateExcavateAreas[
        this.estimateExcavateAreaIndex
      ].value
      if (estimateExcavateArea === '其他') {
        estimateExcavateArea = this.otherEstimateExcavateArea
      }
      obj.estimateExcavateArea = estimateExcavateArea

      let estimateExcavateDuration = this.estimateExcavateDurations[
        this.estimateExcavateDurationIndex
      ].value
      if (estimateExcavateDuration === '其他') {
        estimateExcavateDuration = this.otherEstimateExcavateDuration
      }
      obj.estimateExcavateDuration = estimateExcavateDuration

      return obj
    },

    setVM(obj) {
      this.communicateWithProjCompanyDate = this.getYMD(
        obj.communicateWithProjCompanyDate
      )
      this.ifHaveTheConditionsForSurvey = obj.ifHaveTheConditionsForSurvey
      this.surveyEnterDate = this.getYMD(obj.surveyEnterDate)
      this.surveyEndDate = this.getYMD(obj.surveyEndDate)
      this.ifExcavation = obj.ifExcavation

      const remains = obj.remainsInfo
      remains.forEach(item => {
        const data = item.split('|')
        this.remainsInfo.push([data[0], data[1]])
      })

      const area = obj.estimateExcavateArea
      this.estimateExcavateAreas.every((item, index) => {
        if (item.value === area) {
          this.estimateExcavateAreaIndex = index
          return false
        }
        return true
      })

      const duration = obj.estimateExcavateDuration
      this.estimateExcavateDurations.every((item, index) => {
        if (item.value === duration) {
          this.estimateExcavateDurationIndex = index
          return false
        }
        return true
      })

      const notHaveTheConditionsForSurveyReasons =
        obj.notHaveTheConditionsForSurveyReasons
      notHaveTheConditionsForSurveyReasons.forEach(x => {
        let find = false
        this.notHaveTheConditionsForSurveyReasonItems.every(y => {
          if (x === y.value) {
            this.$set(y, 'checked', true)
            find = true
            return false
          }
          return true
        })
        if (!find) {
          this.notHaveTheConditionsForSurveyReasonItems.every(y => {
            if (y.value === '其他') {
              this.$set(y, 'checked', true)
              find = true
              this.$set(y, 'reason', x)
              this.otherNotHaveTheConditionsForSurveyReason = x
              return false
            }
            return true
          })
        }
      })
    }
  }
}
</script>

<style lang="scss" scoped>
.survey {
  .add-remain-info {
    position: fixed;
    top: 0;
    bottom: 0;
    left: 0;
    right: 0;
    background-color: rgba(128, 128, 128, 0.5);
    z-index: 99;

    .content {
      width: 100%;
      background-color: white;
      position: relative;
      //   border-radius: 20rpx;
      padding: 30rpx 0;

      .title {
        text-align: center;
        font-size: 1rem;
        color: #555;
      }

      .close {
        position: absolute;
        top: 0;
        right: 0;
        width: 100rpx;
        height: 100rpx;
        background-color: transparent;

        .x {
          width: 50rpx;
          height: 4rpx;
          background-color: red;
          position: relative;

          &:nth-child(1) {
            transform: rotate(45deg);
            top: 2rpx;
          }
          &:nth-child(2) {
            transform: rotate(-45deg);
            top: -2rpx;
          }
        }
      }

      .picker-view {
        background-color: #e5e5e5;
        height: 200px;
        font-size: 0.9rem;
        z-index: 999;
      }

      .op {
        padding: 10px 20px;

        .ok {
          padding: 10px 40px;
          color: #fff;
          position: relative;
          z-index: 3;
          margin-left: 30px;

          &::after {
            content: ' ';
            // border: 1px solid rgba(0, 0, 0, 0.2);
            box-sizing: border-box;
            border-radius: 10px;
            position: absolute;
            top: 0;
            bottom: 0;
            left: 0;
            right: 0;
            background-color: #007aff;
            z-index: -1;
          }
        }
        .cancel {
          padding: 10px 40px;
          color: #fff;
          position: relative;
          z-index: 3;

          &::after {
            content: ' ';
            // border: 1px solid rgba(0, 0, 0, 0.2);
            box-sizing: border-box;
            border-radius: 10px;
            position: absolute;
            top: 0;
            bottom: 0;
            left: 0;
            right: 0;
            background-color: red;
            z-index: -1;
          }
        }
      }
    }
  }

  .remain-item {
    background-color: #339c23;
    padding: 2px;
    border-radius: 10px;
    margin-left: 10px;
    margin-bottom: 10px;

    .info {
      padding: 0px 5px;
      color: white;

      .type {
        font-size: 0.9rem;
      }
      .period {
        font-size: 0.6rem;
      }
    }

    .delete {
      background-color: transparent;
      //   width: 70rpx;
      height: 100%;
      padding: 0 2px 0 0;

      .x {
        width: 50rpx;
        height: 6rpx;
        background-color: white;
        position: relative;

        &:nth-child(1) {
          transform: rotate(45deg);
          top: 3rpx;
        }
        &:nth-child(2) {
          transform: rotate(-45deg);
          top: -3rpx;
        }
      }
    }
  }
}
</style>
