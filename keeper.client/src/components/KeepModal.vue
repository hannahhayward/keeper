<template>
  <div class="modal fade"
       id="keepModal"
       tabindex="-1"
       aria-labelledby="exampleModalLabel"
       aria-hidden="true"
  >
    <div class="modal-dialog">
      <div class="modal-size">
        <div class="modal-body h-100">
          <div>
            <img class="modal-img" :src="activeKeep.img" alt="">
          </div>
          <div>
            <h6>{{ activeKeep.name }}</h6>
          </div>
        </div>
        <div>
          <div class="dropdown">
            <button class="btn btn-secondary dropdown-toggle"
                    type="button"
                    id="vaultDropdownMenu"
                    data-toggle="dropdown"
                    aria-haspopup="true"
                    aria-expanded="false"
            >
              Dropdown button
            </button>
            <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
              <div class="dropdown-item" v-for="v in vaults" :key="v.id" href="#">
                {{ vault.name }}
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, reactive } from '@vue/runtime-core'
import { AppState } from '../AppState'
export default {
  setup() {
    const state = reactive({
      profile: AppState.account
    })
    return {
      state,
      activeKeep: computed(() => AppState.activeKeep),
      vaults: computed(() => AppState.activeProfileVaults)
    }
  }
}
</script>

<style>
.modal-size{
  position: relative;
    display: flex;
    flex-direction: column;
    width: auto;
    height: auto;
    pointer-events: auto;
    background-color: #fff;
    background-clip: padding-box;
    border: 1px solid rgba(0, 0, 0, 0.2);
    border-radius: 0.3rem;
    outline: 0;
}
.modal-img{
  object-fit: contain;
  object-position: center;
  width: -webkit-fill-available;}
</style>
