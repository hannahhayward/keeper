<template>
  <div class="">
    <div class="card"
         @click="getById(keep.id),getProfile(keep.creatorId)"
    >
      <img class="card-img-top"
           :src="keep.img"
           alt="Card image cap"
      >
      <div class="card-img-overlay">
        <div class="card-body height"
             data-toggle="modal"
             data-target="#keepModal"
        ></div>
        <router-link class="link" :to="{name: 'Profile', params:{id: keep.creator.id }}">
          <div class="card-text d-flex ">
            <div class="col-9 text-center">
              <h6> {{ keep.name }}</h6>
            </div>
            <div class="col-2">
              <img :src="keep.creator.picture"
                   :alt="keep.creator.id"
                   class="pic rounded-pill"
              />
            </div>
          </div>
        </router-link>
      </div>
    </div>
  </div>
  <KeepModal />
</template>
<script>
import { profileService } from '../services/ProfileService'
import { keepService } from '../services/KeepService'
import { AppState } from '../AppState'
import { computed } from '@vue/runtime-core'

export default {
  props: { keep: { type: Object, required: true } },
  setup(props) {
    return {
      vaults: computed(() => AppState.activeProfileVaults),
      activeKeep: computed(() => AppState.activeKeep),
      activeProfile: computed(() => AppState.activeProfile),
      async getById(id) {
        try {
          await keepService.getById(id)
        } catch (error) {
          window.alert(error, 'could not find a keep with that id')
        }
      },
      async getProfile(id) {
        try {
          await profileService.getProfile(id)
        } catch (error) {
          window.alert(error, 'could not get profile')
        }
      }
    }
  }
}
</script>

<style scoped>
.pic{
  height: 5vh;
}
h6{
  font-size: 17px;
}
.height{
      height: 98%;
    margin-bottom: -2rem;
}
.link{
  text-decoration: none;
  color: #F0ECEE;
    -webkit-text-stroke: #535353;
    -webkit-text-stroke-width: thin;
}
.card-img-overlay
    {position: absolute;
    top: 0;
    right: 0;
    bottom: 0;
    left: 0;
    padding: 1.25rem;
    border-radius: calc(0.25rem - 1px);
    background-image: linear-gradient(#ff000000, #21211f);}

</style>
