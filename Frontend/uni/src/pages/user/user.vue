<template>
  <uni-indexed-list
    :options="users"
    :showSelect="false"
    @click="onClick"
  ></uni-indexed-list>
</template>

<script>
import uniIndexedList from '@/components/uni-indexed-list/uni-indexed-list.vue'

export default {
  data() {
    return {
      users: [
        {
          letter: 'L',
          data: ['李四']
        },
        {
          letter: 'S',
          data: ['孙七']
        },
        {
          letter: 'W',
          data: ['王五']
        },
        {
          letter: 'Z',
          data: ['张三', '张二', '赵六', '周八']
        }
      ]
    }
  },
  components: {
    uniIndexedList
  },
  methods: {
    onClick(e) {
      console.log(e)
    }
  }
}
</script>

<style lang="scss" scoped></style>
