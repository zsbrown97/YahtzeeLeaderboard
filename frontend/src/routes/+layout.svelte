<script lang="ts">
	import NavHeader from '$lib/components/NavHeader.svelte';
	import favicon from '$lib/assets/favicon.svg';

	import "../app.css";

	let { children } = $props();
</script>

<svelte:head>
	<link rel="icon" href={favicon} />
</svelte:head>

<NavHeader />

{@render children?.()}
