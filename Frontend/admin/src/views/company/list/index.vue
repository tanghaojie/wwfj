<template>
  <div class="company-container">
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
      element-loading-text="加载中..."
      border
      fit
      class="table"
    >
      <el-table-column label="企业名称" align="center">
        <template slot-scope="scope">
          {{ scope.row.name }}
        </template>
      </el-table-column>

      <el-table-column label="注册地址" align="center">
        <template slot-scope="scope">
          <span>{{ scope.row.registeredLocation }}</span>
        </template>
      </el-table-column>

      <el-table-column label="统一社会信用代码" align="center">
        <template slot-scope="scope">
          {{ scope.row.unifiedSocialCreditCode }}
        </template>
      </el-table-column>

      <el-table-column align="center" label="联系人">
        <template slot-scope="scope">
          {{ scope.row.responsiblePerson }}
        </template>
      </el-table-column>

      <el-table-column align="center" label="联系方式">
        <template slot-scope="scope">
          {{ scope.row.contactInfo }}
        </template>
      </el-table-column>

      <el-table-column label="操作" align="center">
        <template slot-scope="scope">
          <el-button
            size="medium "
            type="danger"
            @click="handleDelete(scope.row)"
          >
            删除
          </el-button>
        </template>
      </el-table-column>
    </el-table>
  </div>
</template>

<script>
import { get, getAll, createCompany, deleteCompany } from '@/api/company'
import { Message, MessageBox } from 'element-ui'

export default {
  name: 'Company',
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
    this.getCompanies()
  },
  methods: {
    handleDelete(row) {
      MessageBox.confirm(
        `是否确认删除单位[ ${row.name} ]的所有信息？此操作不可恢复`,
        '警告',
        {
          type: 'warning'
        }
      )
        .then(() => {
          this.listLoading = true
          deleteCompany({
            id: row.id
          })
            .then(res => {
              this.getCompanies()
              this.listLoading = false
            })
            .catch(() => {
              this.getCompanies()
              this.listLoading = false
            })
        })
        .catch(() => {})
    },
    handleSizeChange(val) {
      this.pageSize = val
      this.getCompanies()
    },
    handleCurrentChange(val) {
      this.currentPage = val
      this.getCompanies()
    },
    getCompanies() {
      this.list = []
      // this.listTotal = 0
      this.listLoading = true
      return getAll({
        skipCount: this.skip,
        maxResultCount: this.pageSize
      }).then(response => {
        const data = response.result
        this.list = data.items
        this.listTotal = data.totalCount
        this.listLoading = false
      })
    }
  }
}
</script>

<style lang="scss" scoped>
.company-container {
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
