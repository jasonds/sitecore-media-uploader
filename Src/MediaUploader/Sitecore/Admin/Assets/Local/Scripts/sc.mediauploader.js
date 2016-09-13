var sc = sc || {};

sc.mediauploader = (function($) {
    var pub = {};

    function disableInputs() {
        var $inputs = $('.upload-disable');
        $inputs.prop('disabled', true);
    }

    // View blob details
    pub.onViewDetails = function(details) {
        if (details) {
            var content = JSON.parse(details);
            if (content) {
                var $modal = $('#blobDetailsModal');
                var $name = $($modal.find('#blobDetailsContentName'));
                var $cdnEndpoint = $($modal.find('#blobDetailsContentCdnEndpoint'));
                var $storageEndpoint = $($modal.find('#blobDetailsContentStorageEndpoint'));

                $name.text(content.Name);
                $cdnEndpoint.text(content.CdnEndpoint);
                $storageEndpoint.text(content.StorageEndpoint);
            }
        }

        $('#blobDetailsModal').modal('show');

        return false;
    };

    // Handle delete client side
    pub.onDelete = function () {
        // Validate
        if (!confirm('Delete this blob?')) {
            return false;
        }

        // Proceed with deletion
        disableInputs();

        return true;
    };

    // Handle delete all client side
    pub.onDeleteAll = function () {
        // Validate
        var length = $('[id*=cbSelectRow]:checked').length;

        if (length > 0) {
            var message = 'Delete selected blobs?';
            if (length === 1) {
                message = 'Delete selected blob?';
            }

            if (!confirm(message)) {
                return false;
            }
        } else {
            alert('Select at least one blob.');
            return false;
        }

        // Proceed with deletion
        disableInputs();

        return true;
    };

    // Handle blob upload client side
    pub.onUpload = function () {
        disableInputs();

        var $imgUploadLoadingIndicatorContainer = $('[id*=imgUploadLoadingIndicatorContainer]');
        $imgUploadLoadingIndicatorContainer.addClass('shown');
    };

    (function init() {
        // Wire up the check / uncheck all logic
        var $selectAllSelector = $('#mediaUploaderBlobList [id*=cbSelectAll]');
        var $selectRowSelector = $('#mediaUploaderBlobList [id*=cbSelectRow]');

        $selectAllSelector.click(function () {
            if ($(this).is(':checked')) {
                $selectRowSelector.prop('checked', true);
            } else {
                $selectRowSelector.prop('checked', false);
            }
        });
        $selectRowSelector.click(function () {
            if ($selectRowSelector.length === $('#mediaUploaderBlobList [id*=cbSelectRow]:checked').length) {
                $selectAllSelector.prop('checked', true);
            } else {
                $selectAllSelector.prop('checked', false);
            }
        });
    })();

    return pub;
})(jQuery);
