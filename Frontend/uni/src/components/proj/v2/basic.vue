<template>
  <view class="basic">
    <simple-address
      ref="addressPicker"
      themeColor="#007AFF"
      :pickerValueDefault="locRegion.index"
      @onConfirm="onAddresPickerConfirm"
    ></simple-address>

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
        />
      </view>
    </view>

    <!-- 项目单位 -->
    <view class="input-group">
      <view class="title">
        <text class="title-text ">项目单位</text>
      </view>
      <view class="input-wrapper">
        <button
          size="mini"
          class="button-input"
          :style="{
            color: projCompany.name ? '#000' : '#858585'
          }"
          @click="selectProjCompany"
        >
          {{ this.projCompany.name || '点击选择项目单位' }}
        </button>
        <icon
          type="clear"
          size="24"
          style="margin: 0 10px;"
          @click="clearProjCompany"
          v-show="projCompany.name"
        />
      </view>
    </view>

    <!-- 所在区域 -->
    <view class="input-group j-flex j-flex-row ">
      <view class="title">
        <text class="title-text ">所在区域</text>
      </view>
      <view class="input-inline-wrapper">
        <view @click="openAddresPicker" class="text-center">
          {{ locRegion.label }}
        </view>
      </view>
    </view>

    <!-- 详细位置 -->
    <view class="input-group">
      <view class="title"><text class="title-text">详细位置</text></view>
      <view class="input-wrapper">
        <input
          class="input"
          @input="onLocDetailInput"
          placeholder="请输入详细位置"
          :value="locDetail"
        />
      </view>
    </view>

    <!-- 土地用地性质 -->
    <view class="input-group j-flex j-flex-row ">
      <view class="title">
        <text class="title-text">土地用地性质</text>
      </view>
      <view class="input-inline-wrapper">
        <picker
          mode="selector"
          :value="landPropIndex"
          :range="landProps"
          range-key="value"
          class="text-center"
          @change="onLandPropChange"
        >
          <view class="">{{ landProps[landPropIndex].value }}</view>
        </picker>
      </view>
    </view>

    <!-- 是否重点项目 -->
    <view class="input-group j-flex j-flex-row ">
      <view class="title j-flex j-flex-row j-flex-center ">
        <text class="title-text">是否重点项目</text>
      </view>
      <view class="input-inline-wrapper j-flex j-flex-row j-flex-center ">
        <switch @change="majorProjChange" :checked="majorProj" style="" />
      </view>
    </view>

    <!-- 资料提交时间 -->
    <view class="input-group j-flex j-flex-row ">
      <view class="title">
        <text class="title-text">资料提交时间</text>
      </view>
      <view class="input-inline-wrapper">
        <picker
          mode="date"
          :value="documentSubmitDate"
          @change="onDocumentSubmitDateChange"
          class="text-center"
        >
          <view class="text-center">{{ documentSubmitDate }}</view>
        </picker>
      </view>
    </view>

    <!-- 纸质资料审核完成时间 -->
    <view class="input-group j-flex j-flex-row ">
      <view class="title">
        <text class="title-text">纸质资料审核完成时间</text>
      </view>
      <view class="input-inline-wrapper">
        <picker
          mode="date"
          :value="paperDocumentReviewCompletionDate"
          @change="onPaperDocumentReviewCompletionDateChange"
          class="text-center"
        >
          <view class="text-center">{{
            paperDocumentReviewCompletionDate
          }}</view>
        </picker>
      </view>
    </view>

    <!-- 现场核实完成时间 -->
    <view class="input-group j-flex j-flex-row ">
      <view class="title">
        <text class="title-text">现场核实完成时间</text>
      </view>
      <view class="input-inline-wrapper">
        <picker
          mode="date"
          :value="onSiteVerificationCompletionDate"
          @change="onOnSiteVerificationCompletionDateChange"
          class="text-center"
        >
          <view class="text-center">{{
            onSiteVerificationCompletionDate
          }}</view>
        </picker>
      </view>
    </view>

    <!-- 是否具备考古调查勘探条件 -->
    <view class="input-group j-flex j-flex-row ">
      <view class="title j-flex j-flex-row j-flex-center ">
        <text class="title-text">是否具备考古调查勘探条件</text>
      </view>
      <view class="input-inline-wrapper j-flex j-flex-row j-flex-center ">
        <switch @change="ifSurveyChange" :checked="ifSurvey" style="" />
      </view>
    </view>

    <view v-show="!ifSurvey">
      <!-- 不具备考古调查勘探条件原因 -->
      <view class="input-group">
        <view class="title"
          ><text class="title-text">不具备考古调查勘探条件原因</text></view
        >
        <view class="input-wrapper">
          <checkbox-group
            @change="onNotSurveyReasonsChange"
            class="j-w-100"
            style="font-size: 0.8rem"
          >
            <label
              v-for="item in notSurveyReasonItems"
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
                  @input="onOtherNotSurveyReasonChange"
                  placeholder="请输入"
                  :value="otherNotSurveyReason"
                  style="font-size: 0.8rem; color: #000; margin-left: 10px"
                />
              </view>
            </label>
          </checkbox-group>
        </view>
      </view>
    </view>

    <view v-show="ifSurvey">
      <!-- 考古工作方式 -->
      <view class="input-group">
        <view class="title">
          <text class="title-text title-text-require ">考古工作方式</text>
        </view>
        <view class="input-wrapper">
          <radio-group
            @change="onSurveyWorkTypeChange"
            class="j-flex j-flex-row j-w-100"
            style="justify-content: space-around; align-items: center"
          >
            <label
              class="j-flex j-flex-row j-flex-center"
              v-for="(item, index) in surveyWorkTypes"
              :key="item.value"
            >
              <view>
                <radio
                  :value="item.value"
                  :checked="index === surveyWorkTypesCurrent"
                />
              </view>
              <view>{{ item.value }}</view>
            </label>
          </radio-group>
        </view>
      </view>

      <!-- 是否签订文勘协议 -->
      <view class="input-group j-flex j-flex-row ">
        <view class="title j-flex j-flex-row j-flex-center ">
          <text class="title-text">是否签订文勘协议</text>
        </view>
        <view class="input-inline-wrapper j-flex j-flex-row j-flex-center ">
          <switch
            @change="ifSignSurveyAgreementChange"
            :checked="ifSignSurveyAgreement"
            style=""
          />
        </view>
      </view>

      <view v-show="ifSignSurveyAgreement">
        <!-- 向项目单位发送协议时间 -->
        <view class="input-group j-flex j-flex-row ">
          <view class="title">
            <text class="title-text">向项目单位发送协议时间</text>
          </view>
          <view class="input-inline-wrapper">
            <picker
              mode="date"
              :value="sendSurveyAgreementDate"
              @change="onSendSurveyAgreementDateChange"
              class="text-center"
            >
              <view class="text-center">{{ sendSurveyAgreementDate }}</view>
            </picker>
          </view>
        </view>

        <!-- 反馈盖章协议时间 -->
        <view class="input-group j-flex j-flex-row ">
          <view class="title">
            <text class="title-text">反馈盖章协议时间</text>
          </view>
          <view class="input-inline-wrapper">
            <picker
              mode="date"
              :value="replyStampedSurveyAgreementDate"
              @change="onReplyStampedSurveyAgreementDateChange"
              class="text-center"
            >
              <view class="text-center">{{
                replyStampedSurveyAgreementDate
              }}</view>
            </picker>
          </view>
        </view>

        <!-- 正式签订协议时间 -->
        <view class="input-group j-flex j-flex-row ">
          <view class="title">
            <text class="title-text">正式签订协议时间</text>
          </view>
          <view class="input-inline-wrapper">
            <picker
              mode="date"
              :value="signSurveyAgreementDate"
              @change="onSignSurveyAgreementDateChange"
              class="text-center"
            >
              <view class="text-center">{{ signSurveyAgreementDate }}</view>
            </picker>
          </view>
        </view>

        <!-- 协议编号 -->
        <view class="input-group">
          <view class="title"><text class="title-text">协议编号</text></view>
          <view class="input-wrapper">
            <input
              class="input"
              @input="onSurveyAgreementNumberInput"
              placeholder="请输入协议编号"
              :value="surveyAgreementNumber"
            />
          </view>
        </view>
      </view>

      <!-- 工作任务派出时间 -->
      <view class="input-group j-flex j-flex-row ">
        <view class="title">
          <text class="title-text">工作任务派出时间</text>
        </view>
        <view class="input-inline-wrapper">
          <picker
            mode="date"
            :value="taskExclusionDate"
            @change="onTaskExclusionDateChange"
            class="text-center"
          >
            <view class="text-center">{{ taskExclusionDate }}</view>
          </picker>
        </view>
      </view>

      <!-- 实施部门 -->
      <view class="input-group">
        <view class="title"><text class="title-text">实施部门</text></view>
        <view class="input-wrapper">
          <input
            class="input"
            @input="onSurveyDepartmentInput"
            placeholder="请输入实施部门"
            :value="surveyDepartment"
          />
        </view>
      </view>
    </view>
  </view>
</template>

<script>
import simpleAddress from '@/components/simple-address/simple-address.vue'

export default {
  components: { simpleAddress },
  props: {},
  data() {
    return {
      projName: '',
      projCompany: {
        name: '',
        registeredLocation: null,
        unifiedSocialCreditCode: null,
        responsiblePerson: null,
        contactInfo: null,
        creationTime: null,
        id: null
      },

      locRegion: {
        label: '',
        index: [22, 0, 0]
      },
      locDetail: null,

      landPropIndex: 0,
      landProps: [
        { value: '' }
        // { value: '上市' },
        // { value: '协议出让' },
        // { value: '划拨' },
        // { value: '自由土地' }
      ],

      majorProj: false,

      documentSubmitDate: '',
      paperDocumentReviewCompletionDate: '',
      onSiteVerificationCompletionDate: '',

      ifSurvey: false,

      notSurveyReasonItems: [
        // {
        //   value: '项目征地拆迁未完成'
        // },
        // {
        //   value: '项目已完成施工'
        // },
        // {
        //   value: '不具备文勘条件'
        // },
        {
          value: '其他'
        }
      ],
      otherNotSurveyReason: '',

      surveyWorkTypes: [
        {
          value: '勘察'
        },
        {
          value: '调查'
        }
      ],
      surveyWorkTypesCurrent: 0,

      ifSignSurveyAgreement: false,

      sendSurveyAgreementDate: '',

      replyStampedSurveyAgreementDate: '',

      signSurveyAgreementDate: '',

      surveyAgreementNumber: '',

      taskExclusionDate: '',

      surveyDepartment: ''
    }
  },
  computed: {},
  watch: {},
  created() {},
  mounted() {},
  methods: {
    onProjNameInput(e) {
      this.projName = e.detail.value
    },

    selectProjCompany() {
      const emitName = 'Pages.Indexv2.Project'
      const self = this
      uni.$once(emitName, function(data) {
        self.projCompany = data
      })
      uni.navigateTo({
        url: '/pages/indexv2/projCompanySelect?emitName=' + emitName
      })
    },

    clearProjCompany() {
      this.projCompany.name = null
      this.projCompany.registeredLocation = null
      this.projCompany.unifiedSocialCreditCode = null
      this.projCompany.responsiblePerson = null
      this.projCompany.contactInfo = null
      this.projCompany.creationTime = null
      this.projCompany.id = null
    },

    openAddresPicker() {
      this.$refs.addressPicker.open()
    },
    onAddresPickerConfirm(e) {
      this.locRegion.label = e.label
      this.locRegion.index = e.value
    },

    onLocDetailInput(e) {
      this.locDetail = e.detail.value
    },

    onLandPropChange(e) {
      this.landPropIndex = e.detail.value
    },

    majorProjChange(e) {
      this.majorProj = e.target.value
    },

    onDocumentSubmitDateChange(e) {
      this.documentSubmitDate = e.target.value
    },

    onPaperDocumentReviewCompletionDateChange(e) {
      this.paperDocumentReviewCompletionDate = e.target.value
    },
    onOnSiteVerificationCompletionDateChange(e) {
      this.onSiteVerificationCompletionDate = e.target.value
    },

    ifSurveyChange(e) {
      this.ifSurvey = e.target.value
    },

    onNotSurveyReasonsChange(e) {
      var items = this.notSurveyReasonItems,
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

    onOtherNotSurveyReasonChange(e) {
      this.otherNotSurveyReason = e.detail.value
      var items = this.notSurveyReasonItems
      for (var i = 0, lenI = items.length; i < lenI; ++i) {
        const item = items[i]
        if (item.value === '其他') {
          this.$set(item, 'reason', this.otherNotSurveyReason)
        }
      }
    },

    onSurveyWorkTypeChange(e) {
      for (let i = 0; i < this.surveyWorkTypes.length; i++) {
        if (this.surveyWorkTypes[i].value === e.target.value) {
          this.surveyWorkTypesCurrent = i
          break
        }
      }
    },

    ifSignSurveyAgreementChange(e) {
      this.ifSignSurveyAgreement = e.target.value
    },

    onSendSurveyAgreementDateChange(e) {
      this.sendSurveyAgreementDate = e.detail.value
    },

    onReplyStampedSurveyAgreementDateChange(e) {
      this.replyStampedSurveyAgreementDate = e.detail.value
    },

    onSignSurveyAgreementDateChange(e) {
      this.signSurveyAgreementDate = e.detail.value
    },

    onSurveyAgreementNumberInput(e) {
      this.surveyAgreementNumber = e.detail.value
    },

    onTaskExclusionDateChange(e) {
      this.taskExclusionDate = e.detail.value
    },

    onSurveyDepartmentInput(e) {
      this.surveyDepartment = e.detail.value
    },

    getVM() {
      const obj = {
        projName: this.projName,
        projCompanyId: this.projCompany.id,
        regionName: this.locRegion.label,
        locationDetail: this.locDetail,
        landPropertyName: this.landProps[this.landPropIndex].value,
        majorProj: this.majorProj,
        documentSubmitDate: this.documentSubmitDate,
        paperDocumentReviewCompletionDate: this
          .paperDocumentReviewCompletionDate,
        onSiteVerificationCompletionDate: this.onSiteVerificationCompletionDate,
        ifSurvey: this.ifSurvey,
        surveyWorkType: this.surveyWorkTypes[this.surveyWorkTypesCurrent].value,
        ifSignSurveyAgreement: this.ifSignSurveyAgreement,
        sendSurveyAgreementDate: this.sendSurveyAgreementDate,
        replyStampedSurveyAgreementDate: this.replyStampedSurveyAgreementDate,
        signSurveyAgreementDate: this.signSurveyAgreementDate,
        surveyAgreementNumber: this.surveyAgreementNumber,
        taskExclusionDate: this.taskExclusionDate,
        surveyDepartment: this.surveyDepartment
      }
      const notSurveyReasonItems = []
      this.notSurveyReasonItems.forEach(q => {
        if (q.checked) {
          const value = q.value
          if (value === '其他') {
            notSurveyReasonItems.push(q.reason)
          } else {
            notSurveyReasonItems.push(q.value)
          }
        }
      })
      obj.notSurveyReasons = notSurveyReasonItems
      return obj
    },

    setVM(obj) {
      this.projName = obj.projName
      if (obj.projCompany) {
        this.projCompany = obj.projCompany
      }

      const regionName = obj.regionName
      if (regionName && regionName.indexOf('-') >= 0) {
        this.locRegion.label = regionName
        const index = this.$refs.addressPicker.queryIndex(
          obj.regionName.split('-'),
          'label'
        )
        this.locRegion.index = index.index
      }

      this.locDetail = obj.locationDetail

      const landPropertyName = obj.landPropertyName
      this.landProps.every((item, index) => {
        if (item.value === landPropertyName) {
          this.landPropIndex = index
          return false
        }
        return true
      })

      this.majorProj = obj.majorProj
      this.documentSubmitDate = this.getYMD(obj.documentSubmitDate)
      this.paperDocumentReviewCompletionDate = this.getYMD(
        obj.paperDocumentReviewCompletionDate
      )
      this.onSiteVerificationCompletionDate = this.getYMD(
        obj.onSiteVerificationCompletionDate
      )
      this.ifSurvey = obj.ifSurvey
      surveyWorkType: this.surveyWorkTypes[this.surveyWorkTypesCurrent].value,
        (this.ifSignSurveyAgreement = obj.ifSignSurveyAgreement)
      this.sendSurveyAgreementDate = this.getYMD(obj.sendSurveyAgreementDate)
      this.replyStampedSurveyAgreementDate = this.getYMD(
        obj.replyStampedSurveyAgreementDate
      )
      this.signSurveyAgreementDate = this.getYMD(obj.signSurveyAgreementDate)
      this.surveyAgreementNumber = obj.surveyAgreementNumber
      this.taskExclusionDate = this.getYMD(obj.taskExclusionDate)
      this.surveyDepartment = obj.surveyDepartment

      const notSurveyReasonItems = obj.notSurveyReasons
      notSurveyReasonItems.forEach(x => {
        let find = false

        this.notSurveyReasonItems.every(y => {
          if (x === y.value) {
            this.$set(y, 'checked', true)
            find = true
            return false
          }
          return true
        })
        if (!find) {
          this.notSurveyReasonItems.every(y => {
            if (y.value === '其他') {
              this.$set(y, 'checked', true)
              find = true
              this.$set(y, 'reason', x)
              this.otherNotSurveyReason = x
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
.basic {
  .button-input {
    background-color: white;
    font-size: 16px;
    width: 100%;
    height: 26px;
    line-height: 26px;
    border-radius: 0;
    padding: 0;
    margin: 0;

    &::after {
      content: ' ';
      width: 100%;
      height: 100%;
      position: absolute;
      top: 0;
      left: 0;
      border: none;
      -webkit-transform: scale(1);
      transform: scale(1);
      -webkit-transform-origin: 0 0;
      transform-origin: 0 0;
      box-sizing: border-box;
      border-radius: 0;
    }
  }
}
</style>
