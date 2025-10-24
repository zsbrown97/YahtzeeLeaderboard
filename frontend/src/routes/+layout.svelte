<script lang="ts">
	import favicon from '$lib/assets/favicon.svg';

	import "../app.css";

	let { children } = $props();
</script>

<svelte:head>
	<link rel="icon" href={favicon} />
</svelte:head>

<nav>
	<a href="/">home</a>
	<a href="/playerSummary">players</a>
	<a href="/mostRecentGame">most recent game</a>
</nav>

{@render children?.()}
