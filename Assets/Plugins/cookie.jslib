mergeInto(LibraryManager.library, {
	
	setHiScore: function(score) {
		document.cookie = 'hi_score=' + score;
	},

	getHiScore: function() {
		var ret = '';
		var name = 'hi_score' + '=';
		var decodedCookie = decodeURIComponent(document.cookie);
		console.log('cookie: ' + decodedCookie);
		var ca = decodedCookie.split(';');
		
		for(var i = 0; i < ca.length; i++) {
			var c = ca[i];
			
			console.log('c: ' + c);
			
			while (c.charAt(0) == ' ') {
				c = c.substring(1);
			}
			
			console.log('c(trimmed): ' + c);
			
			if (c.indexOf(name) == 0) {
				ret = c.substring(name.length, c.length);
				console.log('break.');
				break;
			}
		}
		
		console.log('ret = ' + ret);
		return ret;
	},
});
