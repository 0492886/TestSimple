/*
Copyright (c) 2003-2013, CKSource - Frederico Knabben. All rights reserved.
For licensing, see LICENSE.html or http://ckeditor.com/license
*/

CKEDITOR.editorConfig = function( config )
{
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
    // config.uiColor = '#AADC6E';
    //config.toolbar = 'Basic';
    //config.removePlugins = 'Underline,Subscript,Superscript,About';
    //config.removeButtons = 'Underline,Subscript,Superscript,About';
    
    config.toolbar = 'MyToolbar';

    config.toolbar_MyToolbar =
	[
		{ name: 'document', items: ['NewPage', 'Preview', 'Source'] },
		{ name: 'clipboard', items: ['Cut', 'Copy', 'Paste', 'PasteText', 'PasteFromWord', '-', 'Undo', 'Redo'] },
		{ name: 'editing', items: ['Find', 'Replace', '-', 'SelectAll', '-', 'Scayt'] },
		{
		    name: 'insert', items: ['Image', 'Table', 'HorizontalRule', 'SpecialChar', 'PageBreak']
		    //, 'Iframe']
		},
                '/',
		{ name: 'styles', items: ['Styles', 'Format', 'Font', 'FontSize'] },
	    { name: 'colors', items : [ 'TextColor','BGColor' ] },
		{ name: 'basicstyles', items: ['Bold', 'Italic', 'Strike', '-', 'RemoveFormat'] },
		{ name: 'paragraph', items: ['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent', '-', 'Blockquote'] },
		{ name: 'links', items: ['Link', 'Unlink', 'Anchor'] },
		{ name: 'tools', items: ['Maximize', '-'] }
	];

};
