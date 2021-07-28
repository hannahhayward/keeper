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
import { vaultService } from '../services/VaultService'
import { logger } from '../utils/Logger'

export default {
  name: 'Home',
  setup() {
    const state =
    ({ profile: computed(() => AppState.account) })
    onMounted(() => {
      try {
        vaultService.getVaultsByProfileId(state.profile.id)
        keepService.getKeeps()
      } catch (error) {
        logger.log(error, 'one of the onmounteds did not work bruh')
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
