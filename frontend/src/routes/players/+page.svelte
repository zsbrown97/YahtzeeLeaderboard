<script lang="ts">
    export let data;
    const { players } = data;
</script>

<h1 class="font-bold mb-4 text-2xl">
    Players
</h1>

<ul>
    {#each players as p}
        <li>{p.name}</li>
    {/each}
</ul>
