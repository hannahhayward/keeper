<template>
  <div class="col-4">
    <div class="card" style="width: 18rem;">
      <img :src="keep.img" class="card-img-top" alt="...">
      <div class="card-body">
        <p class="card-text">
          Some quick example text to build on the card title and make up the bulk of the card's content.
        </p>
      </div>
    </div>
  </div>
</template>

<script>
import { reactive } from '@vue/reactivity'
export default {
  setup() {
    const state = reactive({})
    return { state }
  }
}
</script>

<style scoped>

</style>
