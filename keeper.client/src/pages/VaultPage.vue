<template>
  <div class="container-fluid">
    <div class="row">
      <div class="col-10 m-auto">
        <h4>{{ vault.name }}</h4>
        <p>{{ vault.description }}</p>
        <p>{{ vault.name }}</p>
      </div>
    </div>
    <div class="row">
      <div class="col-10 m-auto">
        <p v-if="keeps.length == 0">
          There is no keeps in this vault yet
        </p>
      </div>
    </div>
    <div class="row">
      <KeepCard v-for="k in keeps" :key="k.id" :keep="k" />
    </div>
  </div>
</template>

<script>
import { computed, onMounted } from '@vue/runtime-core'
import { useRoute } from 'vue-router'
import { keepService } from '../services/KeepService'
import { logger } from '../utils/Logger'
import { vaultService } from '../services/VaultService'
import { AppState } from '../AppState'
export default {
  setup() {
    onMounted(() => {
      try {
        vaultService.getById(route.params.id)
        keepService.getKeepsByVaultId(route.params.id)
      } catch (error) {
        logger.log('could not get vault keeps')
      }
    })
    const route = useRoute()
    return {
      route,
      keeps: computed(() => AppState.activeVaultKeeps),
      vault: computed(() => AppState.activeVault)
    }
  }

}
</script>

<style>

</style>
