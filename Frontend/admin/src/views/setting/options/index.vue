<template>
  <div class="options-container">
    <el-dialog
      title="输入新增的可选值"
      :visible.sync="addItemVisible"
      modal-append-to-body
      append-to-body
    >
      <el-form ref="form" label-position="top" label-width="140px">
        <el-form-item label="" prop="name">
          <el-input v-model="addItemValue" />
        </el-form-item>
        <el-form-item>
          <el-button type="primary" @click="handleAddConfirm">
            确定
          </el-button>
        </el-form-item>
      </el-form>
    </el-dialog>
    <el-tabs v-model="activeName" type="card">
      <el-tab-pane
        v-for="(item, index) in options"
        :key="index"
        :label="item.name"
        :name="item.optionType"
      >
        <el-table :data="tableData(item.optionType)" style="width: 100%">
          <el-table-column label="可选值" align="center" width="260">
            <template slot-scope="scope">
              {{ scope.row }}
            </template>
          </el-table-column>

          <el-table-column label="操作" align="center">
            <template slot-scope="scope">
              <el-button
                size="mini"
                type="danger"
                @click="handleDelete(item.optionType, scope.$index, scope.row)"
              >
                删除
              </el-button>
            </template>
          </el-table-column>
        </el-table>

        <el-button
          size="medium"
          type="success"
          :loading="loading"
          style="margin-top: 30px;"
          @click="handleAdd(item.optionType)"
        >
          添加
        </el-button>
        <el-button
          size="medium"
          type="primary"
          :loading="loading"
          style="margin-top: 30px;"
          @click="handleSave(item.optionType)"
        >
          保存
        </el-button>
      </el-tab-pane>
    </el-tabs>
  </div>
</template>

<script>
import { getByType, update } from '@/api/option'
import { Message, MessageBox } from 'element-ui'

export default {
  name: 'Options',
  data() {
    return {
      activeName: 'LandProps',
      options: [
        {
          name: '土地用地性质',
          optionType: 'LandProps'
        },
        {
          name: '不具备调查勘探条件原因',
          optionType: 'NotSurveyReasons'
        },
        {
          name: '不具备入场条件原因',
          optionType: 'NotHaveTheConditionsForSurveyReasons'
        },
        {
          name: '遗存类型',
          optionType: 'RemainTypes'
        },
        {
          name: '遗存年代',
          optionType: 'RemainPeriods'
        },
        {
          name: '不具备考古发掘入场条件原因',
          optionType: 'NotHaveTheConditionsForExcavationReasons'
        },
        {
          name: '预计发掘面积',
          optionType: 'EstimateExcavateAreas'
        },
        {
          name: '预计发掘周期',
          optionType: 'EstimateExcavateDurations'
        }
      ],
      data: [],
      loading: false,
      addItemVisible: false,
      addItemType: '',
      addItemValue: ''
    }
  },
  computed: {},
  mounted() {
    this.getOptions().then(data => (this.data = data))
  },
  methods: {
    tableData(optionType) {
      const obj = this.data.find(x => x.optionType === optionType)
      return obj ? obj.values : undefined
    },
    getOption(type) {
      return new Promise((resolve, reject) => {
        getByType({
          type: type
        })
          .then(res => {
            resolve(res.result)
          })
          .catch(() => {
            reject()
          })
      })
    },
    getOptions() {
      const types = [
        'LandProps',
        'NotSurveyReasons',
        'NotHaveTheConditionsForSurveyReasons',
        'RemainTypes',
        'RemainPeriods',
        'EstimateExcavateAreas',
        'EstimateExcavateDurations',
        'NotHaveTheConditionsForExcavationReasons'
      ]
      const promises = []
      const self = this
      types.forEach(x => {
        promises.push(self.getOption(x))
      })

      return Promise.all(promises)
    },
    handleDelete(type, index, row) {
      const i = this.data.findIndex(x => x.optionType === type)
      const j = this.data[i].values.findIndex(q => q === row)
      this.data[i].values.splice(j, 1)
    },
    handleSave(type) {
      this.loading = true
      const item = this.data.find(x => x.optionType === type)
      update(item).then(() => {
        this.loading = false
      })
    },
    handleAdd(type) {
      this.addItemVisible = true
      this.addItemType = type
    },
    handleAddConfirm() {
      console.log(this.addItemValue)
      const item = this.data.find(x => x.optionType === this.addItemType)
      item.values.push(this.addItemValue)
      this.addItemVisible = false
      this.addItemValue = ''
      this.addItemType = ''
    }
  }
}
</script>

<style lang="scss" scoped>
.options-container {
  & {
    margin: 30px;
  }
  .pager {
    display: flex;
    justify-content: flex-end;
  }
  .table {
    margin-top: 30px;
  }
}
</style>
