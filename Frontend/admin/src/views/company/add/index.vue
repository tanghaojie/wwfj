<template>
  <div class="add-company-container">
    <el-form
      ref="form"
      label-position="top"
      :rules="rules"
      :model="form"
      label-width="140px"
    >
      <el-form-item label="企业名称" prop="name">
        <el-input v-model="form.name" />
      </el-form-item>

      <el-form-item label="企业注册地址">
        <el-input v-model="form.registeredLocation" />
      </el-form-item>

      <el-form-item label="统一社会信用代码">
        <el-input v-model="form.unifiedSocialCreditCode" />
      </el-form-item>

      <el-form-item label="联系人">
        <el-input v-model="form.responsiblePerson" />
      </el-form-item>

      <el-form-item label="联系方式">
        <el-input v-model="form.contactInfo" />
      </el-form-item>

      <el-form-item>
        <el-button type="primary" :loading="loading" @click="onSubmit">
          确定
        </el-button>
      </el-form-item>
    </el-form>
  </div>
</template>

<script>
import { createCompany } from '@/api/company'
import { Message, MessageBox } from 'element-ui'

export default {
  name: 'AddCompany',
  data() {
    const validateName = (rule, value, callback) => {
      if (value.length <= 0) {
        callback(new Error('请输入企业名称'))
      } else {
        callback()
      }
    }
    return {
      form: {
        name: '',
        registeredLocation: '',
        unifiedSocialCreditCode: '',
        responsiblePerson: '',
        contactInfo: ''
      },
      rules: {
        name: [{ required: true, trigger: 'blur', validator: validateName }]
      },
      loading: false
    }
  },
  computed: {},
  mounted() {},
  methods: {
    onSubmit() {
      this.$refs.form.validate(valid => {
        if (valid) {
          this.loading = true
          createCompany(this.form)
            .then(() => {
              this.form.name = ''
              this.form.registeredLocation = ''
              this.form.unifiedSocialCreditCode = ''
              this.form.responsiblePerson = ''
              this.form.contactInfo = ''

              Message.success('添加成功')
            })
            .catch(msg => {})
          this.loading = false
        } else {
          console.log('error submit!!')
          return false
        }
      })
    }
  }
}
</script>

<style lang="scss" scoped>
.add-company-container {
  & {
    margin: 30px;
  }
}
</style>
