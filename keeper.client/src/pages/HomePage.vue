<template>
  <div class="container-fluid">
    <div class="row">
      <KeepCard v-for="k in keeps" :key="k.id" :keep="k" class="mx-1" />
    </div>
  </div>
  <div class="modal fade"
       id="exampleModal"
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
      </div>
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
