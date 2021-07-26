<template>
  <div class="col-4">
    <div class="card" style="width: 18rem;">
      <img :src="keep.img" class="card-img-top" alt="k.id">
      <div class="card-body">
        <p class="card-text">
          {{ keep.name }}
        </p>
        <div class="card-body">
          <p class="text-left">
            <button class="btn-info btn">
              creator will go right here
            </button>
          </p>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { reactive } from '@vue/reactivity'
import { profileService } from '../services/ProfileService'
import { onMounted } from '@vue/runtime-core'
import { keepService } from '../services/KeepService'

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
    onMounted(() => {
      try {
        keepService.getKeeps()
      } catch (error) {
        Notification.toast(error, error)
      }
    })
    return { state }
  }
}
</script>

<style scoped>

</style>
