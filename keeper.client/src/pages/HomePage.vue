<template>
  <div class="container-fluid">
    <div class="row">
      <KeepCard v-for="k in keeps" :key="k.id" :keep="k" />
    </div>
  </div>
</template>

<script>
import { computed, onMounted } from '@vue/runtime-core'
import { AppState } from '../AppState'
import { keepService } from '../services/KeepService'

export default {
  name: 'Home',
  setup() {
    onMounted(() => {
      try {
        keepService.getKeeps()
      } catch (error) {
        Notification.toast(error, error)
      }
    })
    return {
      keeps: computed(() => AppState.keeps),
      activeKeep: computed(() => AppState.activeKeep)
    }
  }
}
</script>

<style scoped lang="scss">
.home{
  text-align: center;
  user-select: none;
  > img{
    height: 200px;
    width: 200px;
  }
}

</style>
