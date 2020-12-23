<template>
  <div class="user-container">
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
      <el-table-column label="用户名" align="center">
        <template slot-scope="scope">
          {{ scope.row.username }}
        </template>
      </el-table-column>

      <el-table-column label="姓名" align="center">
        <template slot-scope="scope">
          <span>{{ scope.row.realname }}</span>
        </template>
      </el-table-column>

      <el-table-column label="电话" align="center">
        <template slot-scope="scope">
          {{ scope.row.phone }}
        </template>
      </el-table-column>

      <el-table-column label="所属区域" align="center">
        <template slot-scope="scope">
          {{ scope.row.regionName }}
        </template>
      </el-table-column>

      <el-table-column align="center" label="注册日期">
        <template slot-scope="scope">
          {{ getYMD(scope.row.creationTime) }}
        </template>
      </el-table-column>

      <el-table-column label="状态" align="center">
        <template slot-scope="scope">
          <el-button
            size="medium "
            :type="scope.row.locked ? 'danger' : 'success'"
            @click="handleUserLock(scope.row)"
          >
            {{ scope.row.locked ? '已锁定' : '正常' }}</el-button
          >
        </template>
      </el-table-column>

      <el-table-column label="操作" align="center">
        <template slot-scope="scope">
          <el-button
            size="medium "
            type="danger"
            @click="resetUserPassword(scope.row)"
          >
            重置密码
          </el-button>
          <el-button
            size="medium "
            type="danger"
            @click="deleteUser(scope.row)"
          >
            删除
          </el-button>
        </template>
      </el-table-column>
    </el-table>
  </div>
</template>

<script>
import { mapGetters } from 'vuex'
import { getAllUserList } from '@/api/user'

export default {
  name: 'User',
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
    ...mapGetters(['name']),
    skip() {
      return (this.currentPage - 1) * this.pageSize
    }
  },
  mounted() {
    this.getUsers()
  },
  methods: {
    handleUserLock(row) {
      console.log(row)
    },
    resetUserPassword(row) {
      console.log(row)
    },
    deleteUser(row) {
      console.log(row)
    },
    handleSizeChange(val) {
      this.pageSize = val
      this.getUsers()
    },
    handleCurrentChange(val) {
      console.log(val)
      this.currentPage = val
      this.getUsers()
    },
    getUsers() {
      this.list = []
      // this.listTotal = 0
      this.listLoading = true
      getAllUserList({
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
.user-container {
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
<style>
.user-container .locked-user-row {
  background: #f1b9b9;
}
</style>
