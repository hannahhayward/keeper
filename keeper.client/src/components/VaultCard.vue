<template>
  <div class="card bg-dark" @click="getById(vault.id, vault.isPrivate)">
    <div class="row d-flex">
      <div class="card-body col-9 text-center">
        <h5 class="card-text" data-toggle="modal" data-target="#exampleModal">
          {{ vault.name }}
        </h5>
        <p>
          {{ vault.description }}
        </p>
      </div>
    </div>
  </div>
</template>
<script>
import { AppState } from '../AppState'
import { computed } from '@vue/runtime-core'
import { vaultService } from '../services/VaultService'
import { router } from '../router'

export default {
  props: { vault: { type: Object, required: true } },
  setup(props) {
    return {
      activeVault: computed(() => AppState.activeVault),
      async getById(id, privacy) {
        try {
          await vaultService.getById(id)
          router.push({ name: 'Vault', params: { id: id } })
        } catch (error) {
          window.alert('this is a private vault')
          router.push({ name: 'Home' })
        }
      }
    }
  }
}
</script>

<style scoped>
.fit{
 object-fit: contain;
}
.pic{
  height: 5vh;
}

.link{
  text-decoration: none;
  color: #F0ECEE;
    -webkit-text-stroke: #535353;
    -webkit-text-stroke-width: thin;
}
</style>
