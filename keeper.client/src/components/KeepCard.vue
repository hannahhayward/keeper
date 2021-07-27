<template>
  <div class="col-3 card">
    <img :src="keep.img" class="fit" :alt="keep.id">
    <div class="card-body">
      <p class="card-text bg-dark">
        {{ keep.name }}
      </p>
      <button type="button" class="btn btn-primary" @click="getById(keep.id)" data-toggle="modal" data-target="#exampleModal">
        Launch demo modal
      </button>
    </div>
  </div>
</template>
<script>
import { reactive } from '@vue/reactivity'
import { profileService } from '../services/ProfileService'
import { keepService } from '../services/KeepService'
import { logger } from '../utils/Logger'
import { AppState } from '../AppState'
import { computed } from '@vue/runtime-core'

export default {
  props: { keep: { type: Object, required: true } },
  setup(props) {
    const state = reactive({
      getProfile(id) {
        try {
          profileService.getProfile(id)
        } catch (error) {
          Notification.toast(error, error)
        }
      }
    })
    return {
      state,
      getById(id) {
        try {
          keepService.getById(id)
        } catch (error) {
          logger.log('not working')
        }
      },
      activeKeep: computed(() => AppState.activeKeep)
    }
  }
}
</script>

<style scoped>
.fit{
  object-fit: cover;
  object-position: center;
  background-image: initial;
  background-repeat: no-repeat;
}

.size{
  min-height: 20vh;
  max-height: 30vh;
}
.card-size{
  width: 20vw;
  height: 40vh;
}

</style>
