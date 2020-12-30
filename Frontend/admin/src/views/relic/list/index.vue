<template>
  <div class="relic-container">
    <el-pagination
      :current-page="currentPage"
      :page-sizes="[5, 10, 20, 30]"
      :page-size="pageSize"
      background
      layout="total, sizes, prev, pager, next"
      :total="listTotal"
      class="pager"
      @size-change="handleSizeChange"
      @current-change="handleCurrentChange"
    >
    </el-pagination>

    <el-table
      v-loading="listLoading"
      :data="list"
      :stripe="true"
      :header-row-class-name="'table-header'"
      element-loading-text="加载中..."
      border
      fit
      size="medium"
      class="table"
    >
      <el-table-column label="操作" align="center">
        <template slot-scope="scope">
          <el-button
            size="mini "
            type="danger"
            @click="handleDelete(scope.row)"
          >
            删除
          </el-button>
        </template>
      </el-table-column>

      <el-table-column label="项目考古工作完成" align="center">
        <template slot-scope="scope">
          {{ scope.row.allFinish ? '是' : '否' }}
        </template>
      </el-table-column>

      <el-table-column label="项目名称" align="center">
        <template slot-scope="scope">
          {{ scope.row.projName }}
        </template>
      </el-table-column>

      <el-table-column label="项目单位" align="center">
        <template slot-scope="scope">
          <span>{{ scope.row.projCompany.name || '' }}</span>
        </template>
      </el-table-column>

      <el-table-column label="所在区域" align="center">
        <template slot-scope="scope">
          {{ scope.row.regionName }}
        </template>
      </el-table-column>

      <el-table-column label="详细位置" align="center">
        <template slot-scope="scope">
          {{ scope.row.locationDetail }}
        </template>
      </el-table-column>

      <el-table-column label="土地用地性质" align="center">
        <template slot-scope="scope">
          {{ scope.row.landPropertyName }}
        </template>
      </el-table-column>

      <el-table-column label="是否重点项目" align="center">
        <template slot-scope="scope">
          {{ scope.row.majorProj ? '是' : '否' }}
        </template>
      </el-table-column>

      <el-table-column label="资料提交时间" min-width="100px" align="center">
        <template slot-scope="scope">
          {{ getYMD(scope.row.documentSubmitDate) }}
        </template>
      </el-table-column>

      <el-table-column
        label="纸质资料审核完成时间"
        min-width="100px"
        align="center"
      >
        <template slot-scope="scope">
          {{ getYMD(scope.row.paperDocumentReviewCompletionDate) }}
        </template>
      </el-table-column>

      <el-table-column
        label="现场核实完成时间"
        min-width="100px"
        align="center"
      >
        <template slot-scope="scope">
          {{ getYMD(scope.row.onSiteVerificationCompletionDate) }}
        </template>
      </el-table-column>

      <el-table-column label="是否具备考古调查勘探条件" align="center">
        <template slot-scope="scope">
          {{ scope.row.ifSurvey ? '是' : '否' }}
        </template>
      </el-table-column>

      <el-table-column
        label="不具备考古调查勘探条件原因"
        min-width="180px"
        align="center"
      >
        <template slot-scope="scope">
          {{ scope.row.notSurveyReasons.toString() }}
        </template>
      </el-table-column>

      <el-table-column label="考古工作方式" align="center">
        <template slot-scope="scope">
          {{ scope.row.surveyWorkType }}
        </template>
      </el-table-column>

      <el-table-column label="是否签订文勘协议" align="center">
        <template slot-scope="scope">
          {{ scope.row.ifSignSurveyAgreement ? '是' : '否' }}
        </template>
      </el-table-column>

      <el-table-column
        label="市考古队向项目单位发送协议时间"
        min-width="100px"
        align="center"
      >
        <template slot-scope="scope">
          {{ getYMD(scope.row.sendSurveyAgreementDate) }}
        </template>
      </el-table-column>

      <el-table-column
        label="项目单位反馈盖章协议时间"
        min-width="100px"
        align="center"
      >
        <template slot-scope="scope">
          {{ getYMD(scope.row.replyStampedSurveyAgreementDate) }}
        </template>
      </el-table-column>

      <el-table-column
        label="正式协议签订时间"
        min-width="100px"
        align="center"
      >
        <template slot-scope="scope">
          {{ getYMD(scope.row.signSurveyAgreementDate) }}
        </template>
      </el-table-column>

      <el-table-column label="协议编号" align="center">
        <template slot-scope="scope">
          {{ scope.row.surveyAgreementNumber }}
        </template>
      </el-table-column>

      <el-table-column
        label="工作任务派出时间"
        min-width="100px"
        align="center"
      >
        <template slot-scope="scope">
          {{ getYMD(scope.row.taskExclusionDate) }}
        </template>
      </el-table-column>

      <el-table-column label="实施部门" align="center">
        <template slot-scope="scope">
          {{ scope.row.surveyDepartment }}
        </template>
      </el-table-column>

      <el-table-column
        label="与项目单位现场沟通时间"
        min-width="100px"
        align="center"
      >
        <template slot-scope="scope">
          {{ getYMD(scope.row.communicateWithProjCompanyDate) }}
        </template>
      </el-table-column>

      <el-table-column label="是否具备考古勘探入场条件" align="center">
        <template slot-scope="scope">
          {{ scope.row.ifHaveTheConditionsForSurvey ? '是' : '否' }}
        </template>
      </el-table-column>

      <el-table-column
        label="不具备考古勘探入场条件原因"
        min-width="150px"
        align="center"
      >
        <template slot-scope="scope">
          {{ scope.row.notHaveTheConditionsForSurveyReasons.toString() }}
        </template>
      </el-table-column>

      <el-table-column
        label="勘探正式入场时间"
        min-width="100px"
        align="center"
      >
        <template slot-scope="scope">
          {{ getYMD(scope.row.surveyEnterDate) }}
        </template>
      </el-table-column>

      <el-table-column label="勘探结束时间" min-width="100px" align="center">
        <template slot-scope="scope">
          {{ getYMD(scope.row.surveyEndDate) }}
        </template>
      </el-table-column>

      <el-table-column label="是否转入考古发掘" align="center">
        <template slot-scope="scope">
          {{ scope.row.ifExcavation ? '是' : '否' }}
        </template>
      </el-table-column>

      <el-table-column
        label="遗存发现基本情况"
        min-width="180px"
        align="center"
      >
        <template slot-scope="scope">
          {{ scope.row.remainsInfo.toString() }}
        </template>
      </el-table-column>

      <el-table-column label="预计发掘面积" align="center">
        <template slot-scope="scope">
          {{ scope.row.estimateExcavateArea }}
        </template>
      </el-table-column>

      <el-table-column label="预计发掘周期" align="center">
        <template slot-scope="scope">
          {{ scope.row.estimateExcavateDuration }}
        </template>
      </el-table-column>

      <el-table-column label="工程项目名称" align="center">
        <template slot-scope="scope">
          {{ scope.row.excavationProjName }}
        </template>
      </el-table-column>

      <el-table-column label="是否具备考古发掘入场条件" align="center">
        <template slot-scope="scope">
          {{ scope.row.ifHaveTheConditionsForExcavation }}
        </template>
      </el-table-column>

      <el-table-column
        label="不具备入场条件原因"
        min-width="220px"
        align="center"
      >
        <template slot-scope="scope">
          {{ scope.row.notHaveTheConditionsForExcavationReasons.toString() }}
        </template>
      </el-table-column>

      <el-table-column label="部分具备发掘入场条件面积" align="center">
        <template slot-scope="scope">
          {{ scope.row.partHaveTheConditionsForExcavationArea }}
        </template>
      </el-table-column>

      <el-table-column label="是否启动考古发掘" align="center">
        <template slot-scope="scope">
          {{ scope.row.ifStartExcavation }}
        </template>
      </el-table-column>

      <el-table-column
        label="考古发掘入场时间"
        min-width="100px"
        align="center"
      >
        <template slot-scope="scope">
          {{ getYMD(scope.row.excavationEnterDate) }}
        </template>
      </el-table-column>

      <el-table-column
        label="部分考古发掘结束时间"
        min-width="100px"
        align="center"
      >
        <template slot-scope="scope">
          {{ getYMD(scope.row.partExcavationEndDate) }}
        </template>
      </el-table-column>

      <el-table-column
        label="全部考古发掘结束时间"
        min-width="100px"
        align="center"
      >
        <template slot-scope="scope">
          {{ getYMD(scope.row.excavationEndDate) }}
        </template>
      </el-table-column>

      <el-table-column
        label="考古发掘协议签订时间"
        min-width="100px"
        align="center"
      >
        <template slot-scope="scope">
          {{ getYMD(scope.row.signExcavationAgreementDate) }}
        </template>
      </el-table-column>

      <el-table-column label="是否缴纳勘探费" align="center">
        <template slot-scope="scope">
          {{ scope.row.ifPaySurveyFee }}
        </template>
      </el-table-column>

      <el-table-column label="勘探费缴纳时间" min-width="100px" align="center">
        <template slot-scope="scope">
          {{ getYMD(scope.row.paySurveyFeeDate) }}
        </template>
      </el-table-column>

      <el-table-column
        label="考古发掘费缴纳时间"
        min-width="100px"
        align="center"
      >
        <template slot-scope="scope">
          {{ getYMD(scope.row.payExcavationFeeDate) }}
        </template>
      </el-table-column>

      <el-table-column
        label="工作信息表出具时间"
        min-width="100px"
        align="center"
      >
        <template slot-scope="scope">
          {{ getYMD(scope.row.workInfoDocumentIssuanceDate) }}
        </template>
      </el-table-column>

      <el-table-column
        label="完毕业务意见书-出具时间"
        min-width="100px"
        align="center"
      >
        <template slot-scope="scope">
          {{ getYMD(scope.row.workFinishInfoDocumentIssuanceDate) }}
        </template>
      </el-table-column>

      <el-table-column
        label="完毕业务意见书-通知项目单位领取时间"
        min-width="100px"
        align="center"
      >
        <template slot-scope="scope">
          {{ getYMD(scope.row.noticeOfReceiveWorkFinishInfoDocumentDate) }}
        </template>
      </el-table-column>

      <el-table-column label="完毕业务意见书-是否领取" align="center">
        <template slot-scope="scope">
          {{ scope.row.receivedWorkFinishInfoDocument ? '是' : '否' }}
        </template>
      </el-table-column>

      <el-table-column
        label="完毕通知书-出具时间"
        min-width="100px"
        align="center"
      >
        <template slot-scope="scope">
          {{ getYMD(scope.row.finishDocumentIssuanceDate) }}
        </template>
      </el-table-column>

      <el-table-column
        label="完毕通知书-通知项目单位领取时间"
        min-width="100px"
        align="center"
      >
        <template slot-scope="scope">
          {{ getYMD(scope.row.noticeOfReceiveFinishDocumentDate) }}
        </template>
      </el-table-column>

      <el-table-column label="完毕通知书-是否领取" align="center">
        <template slot-scope="scope">
          {{ scope.row.receivedFinishDocument ? '是' : '否' }}
        </template>
      </el-table-column>
    </el-table>
  </div>
</template>

<script>
import { get, getAllList, deleteRelic } from '@/api/relic'
import { Message, MessageBox } from 'element-ui'

export default {
  name: 'Relic',
  data() {
    return {
      list: [],
      listTotal: 0,
      listLoading: false,
      currentPage: 1,
      pageSize: 10
    }
  },
  computed: {
    skip() {
      return (this.currentPage - 1) * this.pageSize
    }
  },
  mounted() {
    this.getRelics()
  },
  methods: {
    handleDelete(row) {
      MessageBox.confirm(
        `是否确认删除[ ${row.projName} ]的所有信息？此操作不可恢复`,
        '警告',
        {
          type: 'warning'
        }
      )
        .then(() => {
          this.listLoading = true
          deleteRelic({
            id: row.id
          })
            .then(res => {
              this.getRelics()
              this.listLoading = false
            })
            .catch(() => {
              this.getRelics()
              this.listLoading = false
            })
        })
        .catch(() => {})
    },
    handleSizeChange(val) {
      this.pageSize = val
      this.getRelics()
    },
    handleCurrentChange(val) {
      this.currentPage = val
      this.getRelics()
    },
    getRelics() {
      this.list = []
      // this.listTotal = 0
      this.listLoading = true
      return getAllList({
        skipCount: this.skip,
        maxResultCount: this.pageSize
      }).then(response => {
        const data = response.result
        this.list = data.items
        console.log(this.list)
        this.listTotal = data.totalCount
        this.listLoading = false
      })
    }
  }
}
</script>

<style lang="scss" scoped>
.relic-container {
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
<style lang="scss">
.relic-container {
  .table-header {
    th {
      background-color: #f3f3f3;
    }
  }
}
.el-table td,
.el-table th.is-leaf,
.el-table--border,
.el-table--group {
  border-color: #ddd;
}
.el-table--border::after,
.el-table--group::after,
.el-table::before {
  background-color: #ddd;
}
</style>
