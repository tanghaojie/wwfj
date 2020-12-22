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
        class="sr"
        :style="{
          width: arrowWHUnit,
          height: arrowWHUnit,
          left: arrowWHUnit,
          top: arrowWHUnit,
          'border-top': symbolWidthUnit + ' solid ' + symbolcolor,
          'border-right': symbolWidthUnit + ' solid ' + symbolcolor,
          transform: transform
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
    },
    symbolwidth: {
      type: Number,
      default: 5
    },
    direction: {
      type: String,
      default: 'up' // up down left right
    }
  },
  data() {
    return {}
  },
  computed: {
    arrowWH() {
      return this.wh / 2
    },
    arrowWHUnit() {
      return this.arrowWH.toString() + this.unit
    },
    symbolWidthUnit() {
      return this.symbolwidth.toString() + this.unit
    },
    transform() {
      const d = this.direction.toLowerCase()
      switch (d) {
        case 'up':
          return 'translate(-50%, -25%) rotate(-45deg)'
        case 'down':
          return 'translate(-50%, -75%) rotate(135deg)'
        case 'left':
          return 'translate(-25%, -50%) rotate(-135deg)'
        case 'right':
          return 'translate(-75%, -50%) rotate(45deg)'
        default:
          throw new 'unknow arrow direction'()
      }
    }
  },
  watch: {},
  methods: {},
  mounted() {}
}
</script>

<style lang="scss" scoped>
.plus {
  position: relative;
  z-index: 99;
  border-radius: 50%;

  .sr {
    position: absolute;
  }
}
</style>
