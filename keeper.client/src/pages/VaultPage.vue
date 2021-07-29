<template>
  <div class="container-fluid bg-color text-light">
    <div class="row">
      <div class="col-10 m-auto">
        <h4>{{ vault.name }}</h4>
        <p>{{ vault.description }}</p>
        <p>{{ vault.name }}</p>
        <router-link class="link" :to="{name: 'Profile', params:{id: vault.creatorId }}">
          <i class="mdi mdi-delete-outline" v-if="vault.creatorId === account.id" @click="deleteVault(vault.id)"></i>
        </router-link>
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
      <div class="card-columns " v-if="keeps.length > 0">
        <VaultKeepCard v-for="k in keeps" :key="k.id" :keep="k" />
      </div>
    </div>
  </div>
</template>

<script>
import { computed, onMounted, watchEffect } from '@vue/runtime-core'
import { useRoute } from 'vue-router'
import { keepService } from '../services/KeepService'
import { vaultService } from '../services/VaultService'
import { AppState } from '../AppState'
import { router } from '../router'
import Pop from '../utils/Notifier'
export default {
  setup() {
    onMounted(async() => {
      try {
        Pop.toast(AppState.account.id, 'the id')
        await keepService.getKeepsByVaultId(route.params.id, AppState.account.id)
        await vaultService.getById(route.params.id)
      } catch (error) {
        router.push({ name: 'Home' })
      }
    })
    watchEffect(async() => {
      try {
        await vaultService.getById(route.params.id)
      } catch (error) {
        Pop.toast(error, 'watch didnt work')
      }
    })
    const route = useRoute()
    return {
      async deleteVault(id) {
        try {
          await vaultService.deleteVault(id)
        } catch (error) {
          Pop.toast(error, 'could not delete')
        }
      },
      route,
      keeps: computed(() => AppState.activeVaultKeeps),
      vault: computed(() => AppState.activeVault),
      account: computed(() => AppState.account)
    }
  }

}
</script>

<style>

</style>
