<template>
  <div>
    <div
      class="plus"
      :style="{
        'background-color': bg,
        width: wh + unit,
        height: wh + unit
      }"
    >
      <div
        class="v"
        :style="{
          width: shortUnit,
          height: longUnit,
          left: shortDisUnit,
          top: longDisUnit,
          'background-color': symbolcolor
        }"
      ></div>
      <div
        class="h"
        :style="{
          width: longUnit,
          height: shortUnit,
          left: longDisUnit,
          top: shortDisUnit,
          'background-color': symbolcolor
        }"
      ></div>
    </div>
  </div>
</template>

<script>
export default {
  name: '',
  props: {
    wh: {
      type: Number,
      default: 150
    },
    unit: {
      type: String,
      default: 'px'
    },
    bg: {
      type: String,
      default: '#fff'
    },
    symbolcolor: {
      type: String,
      default: '#000'
    }
  },
  data() {
    return {}
  },
  computed: {
    long() {
      return (this.wh / 3) * 2
    },
    longUnit() {
      return this.long.toString() + this.unit
    },
    short() {
      return this.wh / 15
    },
    shortUnit() {
      return this.short.toString() + this.unit
    },
    longDisUnit() {
      return ((this.wh - this.long) / 2).toString() + this.unit
    },
    shortDisUnit() {
      return ((this.wh - this.short) / 2).toString() + this.unit
    }
  },
  watch: {},
  methods: {}
}
</script>

<style lang="scss" scoped>
.plus {
  position: relative;
  z-index: 99;
  border-radius: 50%;

  .v {
    position: absolute;
    z-index: 999;
  }
  .h {
    position: absolute;
    z-index: 999;
  }
}
</style>
